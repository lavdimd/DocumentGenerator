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
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.DocumentGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentGeneratorController : ControllerBase
    {
        #region Properties

        private readonly IDocumentGeneratorService _documentGeneratorService;
        private readonly IDocumentGeneratorHelper _documentGeneratorHelper;
        private readonly ISapInterfaceTransactionService _sapInterfaceTransactionService;

        #endregion

        #region Ctor

        public DocumentGeneratorController(
          IDocumentGeneratorService documentGeneratorService,
          IDocumentGeneratorHelper documentGeneratorHelper,
          ISapInterfaceTransactionService sapInterfaceTransactionService)
        {
            _documentGeneratorService = documentGeneratorService;
            _documentGeneratorHelper = documentGeneratorHelper;
            _sapInterfaceTransactionService = sapInterfaceTransactionService;
        }

        #endregion


        #region Methods

        [HttpPost("GenerateFile")]
        public async Task<IActionResult> GenerateCsvFile(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            var relDeferredRevenueActualRevenueList = new List<SapInterfaceModel>();

            requestModel.DateFrom = requestModel.DateFrom.Date;
            requestModel.DateTo = requestModel.DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);
            var finalCsvFile = "";

            /// DEBIT Acc. Receivable
            var allRevenuesCollectedForThisInterval = await _documentGeneratorHelper.PrepareAllRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (allRevenuesCollectedForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest("Something went wrong! See logs for more detail informations!");
            }
            if (allRevenuesCollectedForThisInterval.Data != null && allRevenuesCollectedForThisInterval.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(allRevenuesCollectedForThisInterval.Data);
            }

            /// CREDIT Deferred Revenue Acc.
            var deferredRevenuesForThisInterval = await _documentGeneratorHelper.PrepareDeferredRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (deferredRevenuesForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest("Something went wrong! See logs for more detail informations!");
            }
            if (deferredRevenuesForThisInterval.Data != null && deferredRevenuesForThisInterval.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(deferredRevenuesForThisInterval.Data);
            }

            /// DEBIT Deferred Revenue Acc.
            var revenuesFromDeferredRevenuesToBeCollectedWithinThisInterval = await _documentGeneratorHelper.PrepareRevenuesToCollectFromDeferredRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (revenuesFromDeferredRevenuesToBeCollectedWithinThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest("Something went wrong! See logs for more detail informations!");
            }
            if (revenuesFromDeferredRevenuesToBeCollectedWithinThisInterval.Data != null && revenuesFromDeferredRevenuesToBeCollectedWithinThisInterval.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(revenuesFromDeferredRevenuesToBeCollectedWithinThisInterval.Data);
            }

            /// CREDIT Revenue Acc.
            var actualRevenuesForThisInterval = await _documentGeneratorHelper.PrepareActualRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (actualRevenuesForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest("Something went wrong! See logs for more detail informations!");
            }
            if (actualRevenuesForThisInterval.Data != null && actualRevenuesForThisInterval.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(actualRevenuesForThisInterval.Data);
            }


            var csvPrepared = await _documentGeneratorService.ReportAllRevenue(relDeferredRevenueActualRevenueList, cancellationToken);

            finalCsvFile += csvPrepared.Data;

            if (relDeferredRevenueActualRevenueList.Count == 0)
            {
                return Ok("No data for this interval");
            }

            var uploadSuccessfully = await _documentGeneratorService.UploadCsvToFtp(finalCsvFile, requestModel, cancellationToken);

            if (!uploadSuccessfully.Data)
            {
                return BadRequest(uploadSuccessfully.BadRequest(uploadSuccessfully.Message));
            }

            foreach (var model in relDeferredRevenueActualRevenueList)
            {
                var itemAdded = await _sapInterfaceTransactionService.Add(model, requestModel, cancellationToken);
            }


            return Ok(uploadSuccessfully.Data);
        }


        [HttpPost("GenerateCsvFileSecond")]
        public async Task<IActionResult> GenerateCsvFileSecond(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            var relDeferredRevenueActualRevenueList = new List<SapInterfaceModel>();

            requestModel.DateFrom = requestModel.DateFrom.Date;
            requestModel.DateTo = requestModel.DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);

            var finalCsvFile = "";

            var csvHeader = await _documentGeneratorHelper.GenerateCSVHeader(typeof(SapInterfaceModel));
            finalCsvFile += csvHeader.Data;


            var deferredRevenueData = await _documentGeneratorHelper.PrepareDeferredRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (deferredRevenueData.Data != null && deferredRevenueData.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(deferredRevenueData.Data);
            }

            var actualRevenueData = await _documentGeneratorHelper.PrepareActualRevenuesWithinTimePeriod(requestModel, cancellationToken);
            if (actualRevenueData.Data != null && actualRevenueData.Data.Count != 0)
            {
                relDeferredRevenueActualRevenueList.AddRange(actualRevenueData.Data);
            }

            var csvPrepared = await _documentGeneratorService.ReportAllRevenue(relDeferredRevenueActualRevenueList, cancellationToken);

            finalCsvFile += csvPrepared.Data;

            if (finalCsvFile == csvHeader.Data)
            {
                return Ok("No data for this interval");
            }
            if (relDeferredRevenueActualRevenueList.Count == 0)
            {
                return Ok("No data for this interval");
            }

            var uploadSuccessfully = await _documentGeneratorService.UploadCsvToFtp(finalCsvFile, requestModel, cancellationToken);

            if (!uploadSuccessfully.Data)
            {
                return BadRequest(uploadSuccessfully.BadRequest(uploadSuccessfully.Message));
            }

            foreach (var model in relDeferredRevenueActualRevenueList)
            {
                var itemAdded = await _sapInterfaceTransactionService.Add(model, requestModel, cancellationToken);
            }


            return Ok(uploadSuccessfully.Data);
        }


        #endregion

    }
}
