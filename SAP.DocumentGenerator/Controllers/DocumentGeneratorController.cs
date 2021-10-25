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
        private readonly ISapInterfaceTransactionService _sapInterfaceTransactionService;

        public DocumentGeneratorController(
            IDocumentGeneratorService documentGeneratorService,
            IDocumentGeneratorHelper documentGeneratorHelper,
            ISapInterfaceTransactionService sapInterfaceTransactionService)
        {
            _documentGeneratorService = documentGeneratorService;
            _documentGeneratorHelper = documentGeneratorHelper;
            _sapInterfaceTransactionService = sapInterfaceTransactionService;
        }

        [HttpPost("GenerateCsvFile")]
        public async Task<IActionResult> GenerateCsvFile(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            var relDeferredRevenueActualRevenueList = new List<SapInterfaceModel>();

            transactionRequestModel.DateFrom = transactionRequestModel.DateFrom.Date;
            transactionRequestModel.DateTo = transactionRequestModel.DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);

            var finalCsvFile = "";

            var csvHeader = await _documentGeneratorHelper.GenerateCSVHeader(typeof(SapInterfaceModel));
            finalCsvFile += csvHeader.Data;


            var deferredRevenueData = await _documentGeneratorHelper.PrepareDeferredRevenuesWithinTimePeriod(transactionRequestModel, cancellationToken);
            if (deferredRevenueData.Data != null && deferredRevenueData.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(deferredRevenueData.Data);
            }

            var actualRevenueData = await _documentGeneratorHelper.PrepareActualRevenuesWithinTimePeriod(transactionRequestModel, cancellationToken);
            if(actualRevenueData.Data != null && actualRevenueData.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(actualRevenueData.Data);
            }

            var csvPrepared = await _documentGeneratorService.ReportAllRevenue(relDeferredRevenueActualRevenueList, cancellationToken);

            finalCsvFile += csvPrepared.Data;

            if(finalCsvFile == csvHeader.Data)
            {
                return Ok("No data for this interval");
            }
            if(relDeferredRevenueActualRevenueList.Count == 0)
            {
                return Ok("No data for this interval");
            }

            var uploadSuccessfully = await _documentGeneratorService.UploadCsvToFtp(finalCsvFile, transactionRequestModel, cancellationToken);

            if(!uploadSuccessfully.Data)
            {
                return BadRequest(uploadSuccessfully.BadRequest(uploadSuccessfully.Message));
            }

            foreach(var model in relDeferredRevenueActualRevenueList)
            {
                var itemAdded = await _sapInterfaceTransactionService.Add(model, transactionRequestModel,cancellationToken);
            }


            return Ok(uploadSuccessfully.Data);
        }
    }
}
