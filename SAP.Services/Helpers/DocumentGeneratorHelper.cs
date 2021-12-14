using Microsoft.EntityFrameworkCore;
using SAP.Core.Enum;
using SAP.Core.Models;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Helpers.Interfaces;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Helpers
{
    public class DocumentGeneratorHelper : IDocumentGeneratorHelper
    {
        #region Properties

        readonly EcommerceClientContext _context = new();

        private readonly ITransactionHistoryService _transactionHistoryService;
        private readonly IStaticSettingService _staticSettingService;
        private readonly IStoreService _storeService;

        #endregion

        #region Ctor
        
        public DocumentGeneratorHelper(
            ITransactionHistoryService transactionHistoryService,
            IStaticSettingService staticSettingService,
            IStoreService storeService)
        {
            _transactionHistoryService = transactionHistoryService;
            _staticSettingService = staticSettingService;
            _storeService = storeService;
        }

        #endregion

        #region Methods

        public async Task<Response<List<SapInterfaceModel>>> PrepareAllRevenuesWithinTimePeriod(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();

            var allRevenuesWithinTimePeriod = await _transactionHistoryService.GetAllPaymentsWithinSpecificPeriod(requestModel, cancellationToken);

            if (!string.IsNullOrEmpty(allRevenuesWithinTimePeriod.Message))
            {
                return new Response<List<SapInterfaceModel>>(null, message: allRevenuesWithinTimePeriod.Message, statusCode: allRevenuesWithinTimePeriod.StatusCode);
            }

            var store = await _storeService.GetMainStore(cancellationToken);

            var companyCodeKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CompanyCode).ToLower());
            var companyCode = await _staticSettingService.GetSetting(key: companyCodeKey, store.Data?.Id ?? 1);

            var customerInvoiceDebitKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CustomerInvoiceDebit).ToLower());
            var customerInvoicePosting = await _staticSettingService.GetSetting(key: customerInvoiceDebitKey, store.Data?.Id??1);

            var debitIndicatorKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.DebitIndicator).ToLower());
            var debitIndicator = await _staticSettingService.GetSetting(key: debitIndicatorKey, store.Data?.Id ?? 1);

            var debitAllRevenuesAccountNumberKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.AccountsReceivableAccountNumber).ToLower());
            var debitAllRevenuesAccountNumber = await _staticSettingService.GetSetting(key: debitAllRevenuesAccountNumberKey, store.Data?.Id ?? 1);

            foreach (var customSummaryTransaction in allRevenuesWithinTimePeriod.Data)
            {
                var dateNow = requestModel.DateTo;
                var dateArray = dateNow.ToString("dd.MM.yyyy").Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{companyCode?.Value}",
                    GJAHR = $"{dateNow.Year}",
                    MONAT = $"{dateNow.Month}",
                    BUZEI = $"",
                    BLART = $"CK",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{customerInvoicePosting?.Value}",
                    SHKZG = $"{debitIndicator?.Value}",
                    HKONT = $"{debitAllRevenuesAccountNumber?.Value}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    DMBTR_BRUTTO = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    WRBTR_BRUTTO = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    MWSKZ = $"",
                    MWSTS = $"",
                    WMWST = $"",
                    KOSTL = $"",
                    AUFNR = $"",
                    MENGE = $"",
                    MEINS = $"",
                    PERNR = $"",
                    GSBER = $"VYD",
                    PRCTR = $"",
                    VBUND = $"",
                    BEWAR = $"",
                    FKBER = $"",
                    XREF1 = $"",
                    XREF2 = $"",
                    XREF3 = $"",
                    ZFBDT = $"",
                    BVTYP = $"",
                    ZLSCH = $"",
                    ZTERM = $"",
                    ZLSPR = $"",
                    PROJK = $"",
                    BARCD = $"",
                };

                sapInterfaceModels.Add(sapInterfaceModel);
            }

            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }


        public async Task<Response<List<SapInterfaceModel>>> PrepareDeferredRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();

            var deferredRevenuesWithinTimePeriod = await _transactionHistoryService.GetDeferredRevenuesWithinSpecificPeriod(request, cancellationToken);

            if (!string.IsNullOrEmpty(deferredRevenuesWithinTimePeriod.Message))
            {
                return new Response<List<SapInterfaceModel>>(null, message: deferredRevenuesWithinTimePeriod.Message, statusCode: deferredRevenuesWithinTimePeriod.StatusCode);
            }

            var store = await _storeService.GetMainStore(cancellationToken);

            var companyCodeKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CompanyCode).ToLower());
            var companyCode = await _staticSettingService.GetSetting(key: companyCodeKey, store.Data?.Id ?? 1);

            var generalLedgerCreditKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.GeneralLedgerCredit).ToLower());
            var generalLedgerCreditPosting = await _staticSettingService.GetSetting(key: generalLedgerCreditKey, store.Data?.Id ?? 1);

            var creditIndicatorKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CreditIndicator).ToLower());
            var creditIndicator = await _staticSettingService.GetSetting(key: creditIndicatorKey, store.Data?.Id ?? 1);

            var creditDeferredRevenueAccountNumberKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.DeferredRevenuesAccountNumber).ToLower());
            var creditDeferredRevenuesAccountNumber = await _staticSettingService.GetSetting(key: creditDeferredRevenueAccountNumberKey, store.Data?.Id ?? 1);

            foreach (var customSummaryTransaction in deferredRevenuesWithinTimePeriod.Data)
            {
                var dateNow = request.DateTo;
                var dateArray = dateNow.ToString("dd.MM.yyyy").Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{companyCode?.Value}",
                    GJAHR = $"{dateNow.Year}",
                    MONAT = $"{dateNow.Month}",
                    BUZEI = $"",
                    BLART = $"CK",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{generalLedgerCreditPosting.Value}",
                    SHKZG = $"{creditIndicator?.Value}",
                    HKONT = $"{creditDeferredRevenuesAccountNumber?.Value}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.',','),
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    DMBTR_BRUTTO = $"",
                    WRBTR_BRUTTO = $"",
                    MWSKZ = $"{customSummaryTransaction.ExternalCodeForSAP}",
                    MWSTS = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    WMWST = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    KOSTL = $"",
                    AUFNR = $"{customSummaryTransaction.StoreOrderNumber}",
                    MENGE = $"",
                    MEINS = $"",
                    PERNR = $"",
                    GSBER = $"VYD",
                    PRCTR = $"",
                    VBUND = $"",
                    BEWAR = $"",
                    FKBER = $"",
                    XREF1 = $"",
                    XREF2 = $"",
                    XREF3 = $"",
                    ZFBDT = $"",
                    BVTYP = $"",
                    ZLSCH = $"",
                    ZTERM = $"",
                    ZLSPR = $"",
                    PROJK = $"",
                    BARCD = $"",
                };

                sapInterfaceModels.Add(sapInterfaceModel);
            }

            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }


        public async Task<Response<List<SapInterfaceModel>>> PrepareRevenuesToCollectFromDeferredRevenuesWithinTimePeriod(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();

            var revenuesFromDeferredRevenuesWithinSpecificPeriod = await _transactionHistoryService.GetFromDeferredRevenuesWithinSpecificPeriod(requestModel, cancellationToken);

            if (!string.IsNullOrEmpty(revenuesFromDeferredRevenuesWithinSpecificPeriod.Message))
            {
                return new Response<List<SapInterfaceModel>>(null, message: revenuesFromDeferredRevenuesWithinSpecificPeriod.Message, statusCode: revenuesFromDeferredRevenuesWithinSpecificPeriod.StatusCode);
            }

            var store = await _storeService.GetMainStore(cancellationToken);

            var companyCodeKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CompanyCode).ToLower());
            var companyCode = await _staticSettingService.GetSetting(key: companyCodeKey, store.Data?.Id ?? 1);

            var generalLedgerDebitKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.GeneralLedgerDebit).ToLower());
            var generalLedgerDebitPosting = await _staticSettingService.GetSetting(key: generalLedgerDebitKey, store.Data?.Id ?? 1);

            var debitIndicatorKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.DebitIndicator).ToLower());
            var debitIndicator = await _staticSettingService.GetSetting(key: debitIndicatorKey, store.Data?.Id ?? 1);

            var debitDeferredRevenueAccountNumberKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.DeferredRevenuesAccountNumber).ToLower());
            var debitDeferredRevenueAccountNumber = await _staticSettingService.GetSetting(key: debitDeferredRevenueAccountNumberKey, store.Data?.Id ?? 1);

            foreach (var customSummaryTransaction in revenuesFromDeferredRevenuesWithinSpecificPeriod.Data)
            {
                var dateNow = requestModel.DateTo;
                var dateArray = dateNow.ToString("dd.MM.yyyy").Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{companyCode?.Value}",
                    GJAHR = $"{dateNow.Year}",
                    MONAT = $"{dateNow.Month}",
                    BUZEI = $"",
                    BLART = $"CK",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{generalLedgerDebitPosting?.Value}",
                    SHKZG = $"{debitIndicator?.Value}",
                    HKONT = $"{debitDeferredRevenueAccountNumber?.Value}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    DMBTR_BRUTTO = $"",
                    WRBTR_BRUTTO = $"",
                    MWSKZ = $"{customSummaryTransaction.ExternalCodeForSAP}",
                    MWSTS = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    WMWST = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    KOSTL = $"",
                    AUFNR = $"{customSummaryTransaction.StoreOrderNumber}",
                    MENGE = $"",
                    MEINS = $"",
                    PERNR = $"",
                    GSBER = $"VYD",
                    PRCTR = $"",
                    VBUND = $"",
                    BEWAR = $"",
                    FKBER = $"",
                    XREF1 = $"",
                    XREF2 = $"",
                    XREF3 = $"",
                    ZFBDT = $"",
                    BVTYP = $"",
                    ZLSCH = $"",
                    ZTERM = $"",
                    ZLSPR = $"",
                    PROJK = $"",
                    BARCD = $"",
                };

                sapInterfaceModels.Add(sapInterfaceModel);
            }

            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }


        public async Task<Response<List<SapInterfaceModel>>> PrepareActualRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();
            var customTransactionSummaryList = new List<CustomTransactionSummaryModel>();
            var finalCustomTransactionModels = new List<CustomTransactionSummaryModel>();

            var actualRevenuesWithinPeriod = await _transactionHistoryService.GetActualRevenuesWithinSpecificPeriod(request, asNoTracking: true, cancellationToken);

            if(!string.IsNullOrEmpty(actualRevenuesWithinPeriod.Message) && actualRevenuesWithinPeriod.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return new Response<List<SapInterfaceModel>>(null, message: actualRevenuesWithinPeriod.Message, statusCode: actualRevenuesWithinPeriod.StatusCode);
            }
            if (actualRevenuesWithinPeriod.Data != null && actualRevenuesWithinPeriod.Data.Count != 0)
            {
                customTransactionSummaryList.AddRange(actualRevenuesWithinPeriod.Data);
            }

            var revenuesFromDeferredToActual = await _transactionHistoryService.GetFromDeferredRevenuesWithinSpecificPeriod(request, cancellationToken);
            if(!string.IsNullOrEmpty(revenuesFromDeferredToActual.Message) && revenuesFromDeferredToActual.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return new Response<List<SapInterfaceModel>>(null, message: revenuesFromDeferredToActual.Message, statusCode: revenuesFromDeferredToActual.StatusCode);
            }
            if (revenuesFromDeferredToActual.Data != null && revenuesFromDeferredToActual.Data.Count != 0)
            {
                customTransactionSummaryList.AddRange(revenuesFromDeferredToActual.Data);
            }

            if (customTransactionSummaryList.Count == 0)
            {
                return new Response<List<SapInterfaceModel>>(null, message: $"There is no actual revenues for this interval: {request.DateFrom} - {request.DateTo}", statusCode: (int)HttpStatusCode.NotFound);
            }

            var transactionsGrouped = customTransactionSummaryList.GroupBy(x => new { x.ExternalCodeForSAP, x.StoreOrderNumber, x.Currency });

            foreach (var transaction in transactionsGrouped)
            {
                var totalAmount = (double)transaction.Sum(x => x.TotalAmount);
                var vatRateForCountry = transaction.FirstOrDefault().VATrate;
                var calculatedVATRate = (decimal)(vatRateForCountry / 10.0);
                var netPrice = Math.Round((totalAmount/1.21),2);
                var taxAmount = Math.Round((totalAmount - netPrice),2);

                var customTransactionModel = new CustomTransactionSummaryModel
                {
                    TotalAmount = (decimal)netPrice,
                    NoOfRecords = transaction.Count(),
                    Currency = transaction.Key.Currency,
                    VATrate = transaction.FirstOrDefault().VATrate,
                    StoreOrderNumber = transaction.Key.StoreOrderNumber,
                    ExternalCodeForSAP = transaction.Key.ExternalCodeForSAP,
                    TaxAmountInLocalCurrency = (decimal)taxAmount,
                    SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                };

                finalCustomTransactionModels.Add(customTransactionModel);
            }

            var store = await _storeService.GetMainStore(cancellationToken);

            var companyCodeKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CompanyCode).ToLower());
            var companyCode = await _staticSettingService.GetSetting(key: companyCodeKey, store.Data?.Id ?? 1);

            var generalLedgerCreditKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.GeneralLedgerCredit).ToLower());
            var generalLedgerCreditPosting = await _staticSettingService.GetSetting(key: generalLedgerCreditKey, store.Data?.Id ?? 1);

            var creditIndicatorKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.CreditIndicator).ToLower());
            var creditIndicator = await _staticSettingService.GetSetting(key: creditIndicatorKey, store.Data?.Id ?? 1);

            var creditRevenueAccountNumberKey = string.Format("{0}.{1}", nameof(SapPostingInterfaceSettings).ToLower(), nameof(SapPostingInterfaceSettings.RevenuesAccountNumber).ToLower());
            var creditRevenueAccountNumber = await _staticSettingService.GetSetting(key: creditRevenueAccountNumberKey, store.Data?.Id ?? 1);

            foreach (var customSummaryTransaction in finalCustomTransactionModels)
            {
                var dateNow = request.DateTo;
                var dateArray = dateNow.ToString("dd.MM.yyyy").Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{companyCode?.Value}",
                    GJAHR = $"{dateNow.Year}",
                    MONAT = $"{dateNow.Month}",
                    BUZEI = $"",
                    BLART = $"CK",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{generalLedgerCreditPosting?.Value}",
                    SHKZG = $"{creditIndicator?.Value}",
                    HKONT = $"{creditRevenueAccountNumber?.Value}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}".Replace('.', ','),
                    DMBTR_BRUTTO = $"",
                    WRBTR_BRUTTO = $"",
                    MWSKZ = $"{customSummaryTransaction.ExternalCodeForSAP}",
                    MWSTS = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    WMWST = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}".Replace('.', ','),
                    KOSTL = $"",
                    AUFNR = $"{customSummaryTransaction.StoreOrderNumber}",
                    MENGE = $"",
                    MEINS = $"",
                    PERNR = $"",
                    GSBER = $"VYD",
                    PRCTR = $"",
                    VBUND = $"",
                    BEWAR = $"",
                    FKBER = $"",
                    XREF1 = $"",
                    XREF2 = $"",
                    XREF3 = $"",
                    ZFBDT = $"",
                    BVTYP = $"",
                    ZLSCH = $"",
                    ZTERM = $"",
                    ZLSPR = $"",
                    PROJK = $"",
                    BARCD = $"",
                };

                sapInterfaceModels.Add(sapInterfaceModel);
            }

            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }


        public async Task<Response<string>> PrepareCSVFile(List<SapInterfaceModel> sapInterfaceModels)
        {
            var referenceNumber = GenerateReferenceNumber();
            var csv = "";
            int counter = 1;
            foreach (var item in sapInterfaceModels)
            {
                csv += $"{item.BUKRS}\t" + //BUKRS
                       $"{item.GJAHR}\t" + //GJAHR
                       $"{item.MONAT}\t" + //MONAT
                       $"{counter}\t" +                       //BUZEI
                       $"{item.BLART}\t" + //BLART
                       $"{item.BUDAT}\t" +       //BUDAT
                       $"{item.BLDAT}\t" +       //BLAD
                       $"{item.WAERS}\t" +               //WAERS
                       $"{referenceNumber}\t" +  //XBLNR
                       $"{item.BKTXT}\t" + //BKTXT
                       $"{item.BSCHL}\t" + //BSCHL
                       $"{item.SHKZG}\t" + //SHKZG
                       $"{item.HKONT}\t" + //HKONT
                       $"{item.UMSKZ}\t" +                              //UMSKZ
                       $"{item.ALTKT}\t" +                              //ALTKT
                       $"{item.XNEGP}\t" +                              //XNEGP
                       $"{item.SGTXT}\t" + //SGTXT
                       $"{item.ZUONR}\t" + //ZUONR
                       $"{item.DMBTR}\t" +            //DMBTR
                       $"{item.WRBTR:0.00}\t" +            //WRBTR
                       $"{item.DMBTR_BRUTTO:0.00}\t" +            //DMBTR_BRUTTO
                       $"{item.WRBTR_BRUTTO:0.00}\t" +            //WRBTR_BRUTTO
                       $"{item.MWSKZ}\t" +            //MWSKZ
                       $"{item.MWSTS}\t" + //MWSTS
                       $"{item.WMWST}\t" + //WMWST
                       $"{item.KOSTL}\t" + //KOSTL
                       $"{item.AUFNR}\t" + //AUFNR
                       $"{item.MENGE}\t" + //MENGE
                       $"{item.MEINS}\t" + //MEINS
                       $"{item.PERNR}\t" + //PERNR
                       $"{item.GSBER}\t" + //GSBER
                       $"{item.PRCTR}\t" + //PRCTR
                       $"{item.VBUND}\t" + //VBUND
                       $"{item.BEWAR}\t" + //BEWAR
                       $"{item.FKBER}\t" + //FKBER
                       $"{item.XREF1}\t" + //XREF1
                       $"{item.XREF2}\t" + //XREF2
                       $"{item.XREF3}\t" + //XREF3
                       $"{item.ZFBDT}\t" + //ZFBDT
                       $"{item.BVTYP}\t" + //BVTYP
                       $"{item.ZLSCH}\t" + //ZLSCH
                       $"{item.ZTERM}\t" + //ZTERM
                       $"{item.ZLSPR}\t" + //ZLSPR
                       $"{item.PROJK}\t" + //PROJK
                       $"{item.BARCD}"; //BARCD

                csv += Environment.NewLine;

                counter++;
            }

            return new Response<string>(csv);
        }


        public async Task<Response<string>> GenerateCSVHeader(Type type)
        {
            string csvHeader = "";
            foreach (var prop in type.GetProperties())
            {
                if (prop.Name != "Id")
                {
                    if (csvHeader.Length == 0)
                    {
                        csvHeader += $"{prop.Name}";
                    }
                    else
                    {
                        csvHeader += $", {prop.Name}";
                    }
                }
            }

            return new Response<string>(csvHeader);
        }


        public string GenerateReferenceNumber()
        {
            Random generator = new();
            var randomSixDigitString = generator.Next(0, 10000000).ToString("D6");
            var invoiceNumber = $"REF-{randomSixDigitString}";
            return invoiceNumber;
        }

        #endregion
    }
}
