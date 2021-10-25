using Microsoft.EntityFrameworkCore;
using SAP.Core.Enum;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        readonly EcommerceClientContext _context = new();

        public async Task<Response<List<CustomTransactionSummaryModel>>> GetActualRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            List<CustomTransactionSummaryModel> customResponseList = new List<CustomTransactionSummaryModel>();

            var transactionHistoryListQueryable = _context.TransactionHistories.Where(x => x.CreatedOn >= transactionRequestModel.DateFrom &&
                                                                                      x.CreatedOn <= transactionRequestModel.DateTo &&
                                                                                      x.Deleted == false).AsQueryable();

            if (asNoTracking)
            {
                transactionHistoryListQueryable = transactionHistoryListQueryable.AsNoTracking();
            }

            var paymentIds = await transactionHistoryListQueryable.Select(x => x.PaymentTableId).ToListAsync(cancellationToken);

            if (paymentIds.Count == 0)
            {
                return new Response<List<CustomTransactionSummaryModel>>(null, message: "There is no payment done in this interval");
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
                    StoreOrderNumber = store?.StoreOrderNumber ?? "",
                    VATrate = country.Vatrate,
                    ExternalCodeForSAP = country.ExternalCodeForSap,
                    SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                };

                customResponseList.Add(transactionModel);
            }

            return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
        }

        public async Task<Response<List<CustomTransactionSummaryModel>>> GetFromDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            List<CustomTransactionSummaryModel> customResponseList = new();

            var revenuesWithinPeriod = await _context.DeferredRevenues.Where(x => x.DeferredRevenueDate >= transactionRequestModel.DateFrom
                                                                               && x.DeferredRevenueDate <= transactionRequestModel.DateTo
                                                                               && x.Deleted == false
                                                                             ).ToListAsync(cancellationToken);
            if (revenuesWithinPeriod.Count == 0)
            {
                return new Response<List<CustomTransactionSummaryModel>>(null, message: $"There is no revenue for this interval: {transactionRequestModel.DateFrom} - {transactionRequestModel.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
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
                    StoreOrderNumber = store?.StoreOrderNumber ?? "",
                    VATrate = country.Vatrate,
                    ExternalCodeForSAP = country.ExternalCodeForSap,
                    SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                };

                customResponseList.Add(transactionModel);
            }

            return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
        }

        public async Task<Response<List<CustomTransactionSummaryModel>>> GetDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            List<CustomTransactionSummaryModel> customResponseList = new();


            var deferredRevenues = await _context.Payments.Where(x => x.CreatedOn >= transactionRequestModel.DateFrom
                                                                    && x.CreatedOn <= transactionRequestModel.DateTo
                                                                    && x.IsDeferredRevenue == true
                                                                    && x.Deleted == false).ToListAsync(cancellationToken);

            if (deferredRevenues.Count == 0)
            {
                return new Response<List<CustomTransactionSummaryModel>>(null, message: $"There is no deferred revenue for this interval: {transactionRequestModel.DateFrom} - {transactionRequestModel.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
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
                    StoreOrderNumber = store?.StoreOrderNumber ?? "",
                    VATrate = country.Vatrate,
                    ExternalCodeForSAP = country.ExternalCodeForSap,
                    SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                };

                customResponseList.Add(transactionModel);
            }

            return new Response<List<CustomTransactionSummaryModel>>(customResponseList);
        }
    }
}
