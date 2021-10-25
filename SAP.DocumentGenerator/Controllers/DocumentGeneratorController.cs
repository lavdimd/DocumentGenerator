using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Persistence.Models;
using SAP.Services.Helpers.Interfaces;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.DocumentGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentGeneratorController : ControllerBase
    {
        private readonly IDocumentGeneratorService _documentGeneratorService;
        private readonly IDocumentGeneratorHelper _documentGeneratorHelper;

        public DocumentGeneratorController(
            IDocumentGeneratorService documentGeneratorService,
            IDocumentGeneratorHelper documentGeneratorHelper)
        {
            _documentGeneratorService = documentGeneratorService;
            _documentGeneratorHelper = documentGeneratorHelper;
        }

        [HttpPost("GenerateCsvFile")]
        public async Task<IActionResult> GenerateCsvFile(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            transactionRequestModel.DateFrom = transactionRequestModel.DateFrom.Date;
            transactionRequestModel.DateTo = transactionRequestModel.DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);

            var finalCsvFile = "";

            var csvHeader = await _documentGeneratorHelper.GenerateCSVHeader(typeof(SapInterfaceModel));
            finalCsvFile += csvHeader.Data;

            var deferredRevenuesCsv = await _documentGeneratorService.ReportDeferredRevenues(transactionRequestModel, cancellationToken);
            if(deferredRevenuesCsv.Data != null)
            {
                finalCsvFile += deferredRevenuesCsv.Data;
            }

            var actualRevenuesCsv = await _documentGeneratorService.ReportActualRevenues(transactionRequestModel, cancellationToken);
            if(actualRevenuesCsv.Data != null)
            {
                finalCsvFile += actualRevenuesCsv.Data;
            }

            if(finalCsvFile == csvHeader.Data)
            {
                return Ok("No data for this interval");
            }

            var uploadSuccessfully = await _documentGeneratorService.UploadCsvToFtp(finalCsvFile, cancellationToken);

            if(!uploadSuccessfully.Data)
            {
                return BadRequest(uploadSuccessfully.BadRequest(uploadSuccessfully.Message));
            }

            return Ok(uploadSuccessfully.Data);
        }
    }
}
