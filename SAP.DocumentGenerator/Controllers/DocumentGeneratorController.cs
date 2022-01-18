using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAP.Core.Common.Constants;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Persistence.Models;
using SAP.Services.Helpers.Interfaces;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
        private readonly ILogService _logService;

        #endregion

        #region Ctor

        public DocumentGeneratorController(
          IDocumentGeneratorService documentGeneratorService,
          IDocumentGeneratorHelper documentGeneratorHelper,
          ISapInterfaceTransactionService sapInterfaceTransactionService,
          ILogService logService)
        {
            _documentGeneratorService = documentGeneratorService;
            _documentGeneratorHelper = documentGeneratorHelper;
            _sapInterfaceTransactionService = sapInterfaceTransactionService;
            _logService = logService;
        }

        #endregion


        #region Methods

        [HttpPost("GenerateFile")]
        public async Task<IActionResult> GenerateCsvFile(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                var relDeferredRevenueActualRevenueList = new List<SapInterfaceModel>();

                requestModel.DateFrom = requestModel.DateFrom.Date;
                requestModel.DateTo = requestModel.DateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);
                var finalCsvFile = "";

                var documentType = await _documentGeneratorService.GetTypeOfDocumentToGenerate(requestModel, cancellationToken);

                if (documentType.Data.HasDeferredRevenueInThisInterval)
                {
                    #region Has deferred revenue within this interval

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
                    var deferredRevenuesForThisInterval = await _documentGeneratorHelper.PreparePaymentsWithinSpecificPeriodWhenDeferredRevenuesExist(requestModel, cancellationToken);
                    if (deferredRevenuesForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (deferredRevenuesForThisInterval.Data != null && deferredRevenuesForThisInterval.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(deferredRevenuesForThisInterval.Data);
                    }

                    /// DEBIT DeferredRevenue Acc.
                    var actualRevenuesForThisIntervalWithDeferredRevenue = await _documentGeneratorHelper.PrepareRevenuesFromRegularAndDeferredDebitDeferredRevenues(requestModel, cancellationToken);
                    if (actualRevenuesForThisIntervalWithDeferredRevenue.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (actualRevenuesForThisIntervalWithDeferredRevenue.Data != null && actualRevenuesForThisIntervalWithDeferredRevenue.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(actualRevenuesForThisIntervalWithDeferredRevenue.Data);
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

                    #endregion Has deferred revenue within this interval
                }
                else if (documentType.Data.HasPreviousDeferredRevenue)
                {
                    #region Has deferred revenue from previous months

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

                    /// DEBIT DeferredRevenue Acc.
                    var actualRevenuesForThisIntervalWithDeferredRevenue = await _documentGeneratorHelper.PrepareRevenuesFromDeferredDebitDeferredRevenues(requestModel, cancellationToken);
                    if (actualRevenuesForThisIntervalWithDeferredRevenue.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (actualRevenuesForThisIntervalWithDeferredRevenue.Data != null && actualRevenuesForThisIntervalWithDeferredRevenue.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(actualRevenuesForThisIntervalWithDeferredRevenue.Data);
                    }

                    /// CREDIT Revenue Acc.
                    var actualRevenuesFromDeferredForThisInterval = await _documentGeneratorHelper.PrepareActualRevenuesFromDeferredRevenuesCreditRevenues(requestModel, cancellationToken);
                    if (actualRevenuesFromDeferredForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (actualRevenuesFromDeferredForThisInterval.Data != null && actualRevenuesFromDeferredForThisInterval.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(actualRevenuesFromDeferredForThisInterval.Data);
                    }

                    var actualRevenuesForThisInterval = await _documentGeneratorHelper.PrepareRegularRevenuesWithVATCreditRevenues(requestModel, cancellationToken);
                    if (actualRevenuesForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (actualRevenuesForThisInterval.Data != null && actualRevenuesForThisInterval.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(actualRevenuesForThisInterval.Data);
                    }

                    #endregion Has deferred revenue from previous months
                }
                else
                {
                    #region Regular revenues, without deferred 

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

                    /// CREDIT Revenue Acc.
                    var actualRevenuesForThisInterval = await _documentGeneratorHelper.PrepareRegularRevenuesWithVATCreditRevenues(requestModel, cancellationToken);
                    if (actualRevenuesForThisInterval.StatusCode == (int)HttpStatusCode.BadRequest)
                    {
                        return BadRequest("Something went wrong! See logs for more detail informations!");
                    }
                    if (actualRevenuesForThisInterval.Data != null && actualRevenuesForThisInterval.Data.Count != 0)
                    {
                        relDeferredRevenueActualRevenueList.AddRange(actualRevenuesForThisInterval.Data);
                    }

                    #endregion Regular revenues, without deferred
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

                return Ok("File successfully generated and uploaded on the ftp server!");
            }
            catch (Exception ex)
            {
                await _logService.AddLogAsync(
                    logLevel: LogLevelConstants.SapApiError,
                    shortMessage: $"Something went wrong on method: {MethodBase.GetCurrentMethod()}",
                    fullMessage: $"Full error information for error on method: {MethodBase.GetCurrentMethod()} /n" +
                    $"Exception Message: {ex.Message} /n " +
                    $"Inner Exception: {ex.InnerException?.Message}",
                    cancellationToken);

                return BadRequest("Something went wrong!. Please see the Log table for more detailed exception.");
            }
        }
        #endregion 
    }
}
