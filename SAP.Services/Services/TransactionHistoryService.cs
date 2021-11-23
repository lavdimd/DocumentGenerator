using Microsoft.EntityFrameworkCore;
using SAP.Core.Common.Constants;
using SAP.Core.Enum;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        #region Properties

        readonly EcommerceClientContext _context = new();

        private readonly ILogService _logService;

        #endregion

        #region Ctor

        public TransactionHistoryService(
            ILogService logService)
        {
            _logService = logService;
        }

        #endregion


        #region Methods

        public async Task<Response<List<CustomTransactionSummaryModel>>> GetActualRevenuesWithinSpecificPeriod(TransactionRequestModel requestModel, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            try
            {

                List<CustomTransactionSummaryModel> customResponseList = new List<CustomTransactionSummaryModel>();

                var transactionHistoryListQueryable = _context.TransactionHistories.Where(x => x.CreatedOn >= requestModel.DateFrom &&
                                                                                          x.CreatedOn <= requestModel.DateTo &&
                                                                                          x.Deleted == false).AsQueryable();

                if (asNoTracking)
                {
                    transactionHistoryListQueryable = transactionHistoryListQueryable.AsNoTracking();
                }

                var paymentIds = await transactionHistoryListQueryable.Select(x => x.PaymentTableId).ToListAsync(cancellationToken);

                if (paymentIds.Count == 0)
                {
                    return new Response<List<CustomTransactionSummaryModel>>(null, message: $"There is no payment done in this interval {requestModel.DateFrom} - {requestModel.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
                }

                var payments = await _context.Payments.Where(x => paymentIds.Contains(x.Id) && x.Deleted == false && x.IsDeferredRevenue == false)
                                                      .ToListAsync(cancellationToken);

                var paymentInfoData = await _context.PaymentInfos.Where(x => payments.Select(x => x.Id).ToList().Contains(x.PaymentTableId) && x.Deleted == false)
                                                                 .ToListAsync();

                var dataGrouped = paymentInfoData.GroupBy(x => new { x.CurrencyId, x.CountryId, x.StoreId });

                foreach (var transaction in dataGrouped)
                {
                    var store = await _context.StoreInformations.FirstOrDefaultAsync(x => x.StoreId == transaction.Key.StoreId);
                    var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == transaction.Key.CurrencyId);
                    var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == transaction.Key.CountryId);

                    var paymentTableIds = paymentInfoData.Where(x => x.CurrencyId == transaction.Key.CurrencyId
                                                                && x.StoreId == transaction.Key.StoreId
                                                                && x.CountryId == transaction.Key.CountryId).Select(x => x.PaymentTableId).ToList();

                    var transactionModel = new CustomTransactionSummaryModel
                    {
                        TotalAmount = payments.Where(x => paymentTableIds.Contains(x.Id)).Sum(x => x.Amount),
                        NoOfRecords = paymentTableIds.Count,
                        Currency = currency.CurrencyCode,
                        CountryCode = country.TwoLetterIsoCode,
                        StoreOrderNumber = store.StoreOrderNumber ?? "",
                        VATrate = country.Vatrate,
                        ExternalCodeForSAP = country.ExternalCodeForSap,
                        SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                    };

                    customResponseList.Add(transactionModel);
                }

                return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
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

                return new Response<List<CustomTransactionSummaryModel>>(null, message: "Something went wrong!", statusCode: (int)HttpStatusCode.BadRequest);
            }
        }


        public async Task<Response<List<CustomTransactionSummaryModel>>> GetFromDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                List<CustomTransactionSummaryModel> customResponseList = new();

                var revenuesWithinPeriod = await _context.DeferredRevenues.Where(x => x.DeferredRevenueDate >= requestModel.DateFrom
                                                                                   && x.DeferredRevenueDate <= requestModel.DateTo
                                                                                   && x.Deleted == false
                                                                                 ).ToListAsync(cancellationToken);

                if (revenuesWithinPeriod.Count == 0)
                {
                    return new Response<List<CustomTransactionSummaryModel>>(null, message: $"There is no deferred revenue for this interval: {requestModel.DateFrom} - {requestModel.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
                }

                var dataGrouped = revenuesWithinPeriod.GroupBy(x => new { x.CurrencyId, x.CountryId, x.StoreId });

                foreach (var transaction in dataGrouped)
                {
                    var store = await _context.StoreInformations.FirstOrDefaultAsync(x => x.StoreId == transaction.Key.StoreId);
                    var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == transaction.Key.CurrencyId);
                    var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == transaction.Key.CountryId);

                    var revenuesGroupedByCurrencyCountryStore = revenuesWithinPeriod.Where(x => x.CurrencyId == transaction.Key.CurrencyId
                                                                && x.StoreId == transaction.Key.StoreId
                                                                && x.CountryId == transaction.Key.CountryId).ToList();

                    var transactionModel = new CustomTransactionSummaryModel
                    {
                        TotalAmount = revenuesGroupedByCurrencyCountryStore.Sum(x => x.Amount),
                        NoOfRecords = revenuesGroupedByCurrencyCountryStore.Count,
                        Currency = currency.CurrencyCode,
                        CountryCode = country.TwoLetterIsoCode,
                        StoreOrderNumber = store.StoreOrderNumber ?? "",
                        VATrate = country.Vatrate,
                        ExternalCodeForSAP = country.ExternalCodeForSap,
                        SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                    };

                    customResponseList.Add(transactionModel);
                }

                return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
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

                return new Response<List<CustomTransactionSummaryModel>>(null, message: "Something went wrong!", statusCode: (int)HttpStatusCode.BadRequest);
            }
        }


        public async Task<Response<List<CustomTransactionSummaryModel>>> GetDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                List<CustomTransactionSummaryModel> customResponseList = new();


                var deferredRevenues = await _context.Payments.Where(x => x.CreatedOn >= requestModel.DateFrom
                                                                        && x.CreatedOn <= requestModel.DateTo
                                                                        && x.IsDeferredRevenue == true
                                                                        && x.Deleted == false).ToListAsync(cancellationToken);

                if (deferredRevenues.Count == 0)
                {
                    return new Response<List<CustomTransactionSummaryModel>>(null, message: $"There is no deferred revenue for this interval: {requestModel.DateFrom} - {requestModel.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
                }

                var paymentInformation = await _context.PaymentInfos.Where(x => deferredRevenues.Select(x => x.Id).Contains(x.PaymentTableId)).ToListAsync(cancellationToken);

                var dataGrouped = paymentInformation.GroupBy(x => new { x.CurrencyId, x.CountryId, x.StoreId });

                foreach (var transaction in dataGrouped)
                {
                    var store = await _context.StoreInformations.FirstOrDefaultAsync(x => x.StoreId == transaction.Key.StoreId);
                    var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == transaction.Key.CurrencyId);
                    var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == transaction.Key.CountryId);

                    var paymentTableIds = paymentInformation.Where(x => x.CurrencyId == transaction.Key.CurrencyId
                                                                        && x.StoreId == transaction.Key.StoreId
                                                                        && x.CountryId == transaction.Key.CountryId).Select(x => x.PaymentTableId).ToList();

                    var transactionModel = new CustomTransactionSummaryModel
                    {
                        TotalAmount = deferredRevenues.Where(x => paymentTableIds.Contains(x.Id)).Sum(x => x.Amount),
                        NoOfRecords = paymentTableIds.Count,
                        Currency = currency.CurrencyCode,
                        CountryCode = country.TwoLetterIsoCode,
                        StoreOrderNumber = store.StoreOrderNumber ?? "",
                        VATrate = country.Vatrate,
                        ExternalCodeForSAP = country.ExternalCodeForSap,
                        SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                    };

                    customResponseList.Add(transactionModel);
                }

                return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
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

                return new Response<List<CustomTransactionSummaryModel>>(null, message: "Something went wrong!", statusCode: (int)HttpStatusCode.BadRequest);
            }
        }


        public async Task<Response<List<CustomTransactionSummaryModel>>> GetAllPaymentsWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            try
            {
                List<CustomTransactionSummaryModel> customResponseList = new List<CustomTransactionSummaryModel>();

                var transactionHistoryListQueryable = _context.TransactionHistories.Where(x => x.CreatedOn >= transactionRequestModel.DateFrom &&
                                                                                          x.CreatedOn <= transactionRequestModel.DateTo &&
                                                                                          x.Deleted == false).AsQueryable();

                transactionHistoryListQueryable = transactionHistoryListQueryable.AsNoTracking();

                var paymentIds = await transactionHistoryListQueryable.Select(x => x.PaymentTableId).ToListAsync(cancellationToken);

                if (paymentIds.Count == 0)
                {
                    return new Response<List<CustomTransactionSummaryModel>>(null, message: "There is no payment done in this interval", statusCode: (int)HttpStatusCode.NotFound);
                }

                var payments = await _context.Payments.Where(x => paymentIds.Contains(x.Id) && x.Deleted == false)
                                                      .ToListAsync(cancellationToken);

                var paymentInfoData = await _context.PaymentInfos.Where(x => payments.Select(x => x.Id).ToList().Contains(x.PaymentTableId) && x.Deleted == false)
                                                                 .ToListAsync();

                var dataGrouped = paymentInfoData.GroupBy(x => new { x.CurrencyId, x.CountryId, x.StoreId });

                foreach (var transaction in dataGrouped)
                {
                    var storeInformation = await _context.StoreInformations.FirstOrDefaultAsync(x => x.StoreId == transaction.Key.StoreId);
                    var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == transaction.Key.CurrencyId);
                    var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == transaction.Key.CountryId);

                    var paymentTableIds = paymentInfoData.Where(x => x.CurrencyId == transaction.Key.CurrencyId
                                                                && x.StoreId == transaction.Key.StoreId
                                                                && x.CountryId == transaction.Key.CountryId).Select(x => x.PaymentTableId).ToList();

                    var transactionModel = new CustomTransactionSummaryModel
                    {
                        TotalAmount = payments.Where(x => paymentTableIds.Contains(x.Id)).Sum(x => x.Amount),
                        NoOfRecords = paymentTableIds.Count,
                        Currency = currency.CurrencyCode,
                        CountryCode = country.TwoLetterIsoCode,
                        StoreOrderNumber = storeInformation?.StoreOrderNumber ?? "",
                        VATrate = country.Vatrate,
                        ExternalCodeForSAP = country.ExternalCodeForSap,
                        SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                    };

                    customResponseList.Add(transactionModel);
                }

                return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
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

                return new Response<List<CustomTransactionSummaryModel>>(null, message: "Something went wrong!", statusCode: (int)HttpStatusCode.BadRequest);
            }

        }

        #endregion




    }
}
