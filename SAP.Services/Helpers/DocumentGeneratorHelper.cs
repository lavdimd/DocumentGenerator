using Microsoft.EntityFrameworkCore;
using SAP.Core.Enum;
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
        readonly EcommerceClientContext _context = new();

        private readonly ITransactionHistoryService _transactionHistoryService;


        public DocumentGeneratorHelper(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
        }

        public async Task<Response<List<SapInterfaceModel>>> PrepareActualRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();
            var customTransactionSummaryList = new List<CustomTransactionSummaryModel>();
            var finalCustomTransactionModels = new List<CustomTransactionSummaryModel>();

            var transactionsWithinPeriod = await _transactionHistoryService.GetActualRevenuesWithinSpecificPeriod(request, asNoTracking: true, cancellationToken);
            if (transactionsWithinPeriod.Data != null && transactionsWithinPeriod.Data.Count != 0)
            {
                customTransactionSummaryList.AddRange(transactionsWithinPeriod.Data);
            }

            var transactionsFromDeferredToActive = await _transactionHistoryService.GetRevenuesWithinSpecificPeriod(request, cancellationToken);
            if (transactionsFromDeferredToActive.Data != null && transactionsFromDeferredToActive.Data.Count != 0)
            {
                customTransactionSummaryList.AddRange(transactionsFromDeferredToActive.Data);
            }

            var transactionsGrouped = customTransactionSummaryList.GroupBy(x => new { x.ExternalCodeForSAP, x.StoreOrderNumber, x.Currency });

            foreach (var transaction in transactionsGrouped)
            {
                var customTransactionModel = new CustomTransactionSummaryModel
                {
                    TotalAmount = transaction.Sum(x => x.TotalAmount),
                    NoOfRecords = transaction.Count(),
                    Currency = transaction.Key.Currency,
                    VATrate = transaction.FirstOrDefault().VATrate,
                    StoreOrderNumber = transaction.Key.StoreOrderNumber,
                    ExternalCodeForSAP = transaction.Key.ExternalCodeForSAP,
                    TaxAmountInLocalCurrency = 0, //TODO: refactor this part
                    SapInterfaceType = SapInterfaceObjects.CustomerInvoice
                };

                finalCustomTransactionModels.Add(customTransactionModel);
            }

            var customerInvoiceDebitPostingKey = (int)PostingKey.GeneralLedgerCredit;
            var defaultSapInterfaceModel = await _context.DefaultSapObjectInterfaces.Where(x => x.SapInterfaceType == (int)SapInterfaceObjects.CustomerInvoice
                                                                                           && x.Bschl == customerInvoiceDebitPostingKey.ToString()).FirstOrDefaultAsync(cancellationToken);
            int counter = 1;
            foreach (var customSummaryTransaction in finalCustomTransactionModels)
            {
                var dateNow = DateTime.Now.Date;
                var dateArray = dateNow.ToString().Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{defaultSapInterfaceModel?.Bukrs}",
                    GJAHR = $"{defaultSapInterfaceModel?.Gjahr}",
                    MONAT = $"{defaultSapInterfaceModel?.Monat}",
                    BUZEI = $"{counter}",
                    BLART = $"{defaultSapInterfaceModel?.Blart}",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"{defaultSapInterfaceModel.Xblnr}",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{defaultSapInterfaceModel.Bschl}",
                    SHKZG = $"{defaultSapInterfaceModel.Shkzg}",
                    HKONT = $"{defaultSapInterfaceModel.Hkont}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}",
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}",
                    DMBTR_BRUTTO = $"",
                    WRBTR_BRUTTO = $"",
                    MWSKZ = $"{customSummaryTransaction.ExternalCodeForSAP}",
                    MWSTS = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}",
                    WMWST = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}",
                    KOSTL = $"",
                    AUFNR = $"{customSummaryTransaction.StoreOrderNumber}",
                    MENGE = $"{customSummaryTransaction.NoOfRecords}",
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
                counter++;
            }


            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }

        public async Task<Response<List<SapInterfaceModel>>> PrepareDeferredRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken)
        {
            var sapInterfaceModels = new List<SapInterfaceModel>();

            var deferredRevenuesWithinTimePeriod = await _transactionHistoryService.GetDeferredRevenuesWithinSpecificPeriod(request, cancellationToken);

            if (!string.IsNullOrEmpty(deferredRevenuesWithinTimePeriod.Message))
            {
                return new Response<List<SapInterfaceModel>>(null, message: deferredRevenuesWithinTimePeriod.Message, statusCode: (int)HttpStatusCode.NotFound);
            }

            var generalLedgerCreditPostingKey = (int)PostingKey.CustomerInvoiceDebit;
            var defaultSapInterfaceModel = await _context.DefaultSapObjectInterfaces.Where(x => x.SapInterfaceType == (int)SapInterfaceObjects.CustomerInvoice
                                                                                            && x.Bschl == generalLedgerCreditPostingKey.ToString()
                                                                                           ).FirstOrDefaultAsync(cancellationToken);

            int counter = 1;
            foreach (var customSummaryTransaction in deferredRevenuesWithinTimePeriod.Data)
            {
                var dateNow = DateTime.Now.Date;
                var dateArray = dateNow.ToString().Split(" ");

                var sapInterfaceModel = new SapInterfaceModel()
                {
                    BUKRS = $"{defaultSapInterfaceModel?.Bukrs}",
                    GJAHR = $"{dateNow.Year}",
                    MONAT = $"{dateNow.Month}",
                    BUZEI = $"{counter}",
                    BLART = $"{defaultSapInterfaceModel?.Blart}",
                    BUDAT = $"{dateArray[0]}",
                    BLDAT = $"{dateArray[0]}",
                    WAERS = $"{customSummaryTransaction.Currency}",
                    XBLNR = $"{defaultSapInterfaceModel.Xblnr}",
                    BKTXT = $"Flea Market {dateNow.Month}/{dateNow.Year}",
                    BSCHL = $"{defaultSapInterfaceModel.Bschl}",
                    SHKZG = $"{defaultSapInterfaceModel.Shkzg}",
                    HKONT = $"{defaultSapInterfaceModel.Hkont}",
                    UMSKZ = $"",
                    ALTKT = $"",
                    XNEGP = $"",
                    SGTXT = $"",
                    ZUONR = $"",
                    DMBTR = $"{customSummaryTransaction.TotalAmount:0.00}",
                    WRBTR = $"{customSummaryTransaction.TotalAmount:0.00}",
                    DMBTR_BRUTTO = $"",
                    WRBTR_BRUTTO = $"",
                    MWSKZ = $"{customSummaryTransaction.ExternalCodeForSAP}",
                    MWSTS = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}",
                    WMWST = $"{customSummaryTransaction.TaxAmountInLocalCurrency:0.00}",
                    KOSTL = $"",
                    AUFNR = $"{customSummaryTransaction.StoreOrderNumber}",
                    MENGE = $"{customSummaryTransaction.NoOfRecords}",
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
                counter++;
            }

            return new Response<List<SapInterfaceModel>>(sapInterfaceModels);
        }

        public async Task<Response<string>> PrepareCSVFile(List<SapInterfaceModel> sapInterfaceModels)
        {
            var csv = "";
            foreach (var item in sapInterfaceModels)
            {
                csv += Environment.NewLine;
                csv += $"{item.BUKRS}, " + //BUKRS
                       $"{item.GJAHR}, " + //GJAHR
                       $"{item.MONAT}, " + //MONAT
                       $"{item.BUZEI}, " +                       //BUZEI
                       $"{item.BLART}, " + //BLART
                       $"{item.BUDAT}, " +       //BUDAT
                       $"{item.BLDAT}, " +       //BLAD
                       $"{item.WAERS}, " +               //WAERS
                       $"{item.XBLNR}, " +  //XBLNR
                       $"{item.BKTXT}, " + //BKTXT
                       $"{item.BSCHL}, " + //BSCHL
                       $"{item.SHKZG}, " + //SHKZG
                       $"{item.HKONT}, " + //HKONT
                       $"{item.UMSKZ}, " +                              //UMSKZ
                       $"{item.ALTKT}, " +                              //ALTKT
                       $"{item.XNEGP}, " +                              //XNEGP
                       $"{item.SGTXT}, " + //SGTXT
                       $"{item.ZUONR}, " + //ZUONR
                       $"{item.DMBTR}, " +            //DMBTR
                       $"{item.WRBTR:0.00}, " +            //WRBTR
                       $"{item.DMBTR_BRUTTO:0.00}, " +            //DMBTR_BRUTTO
                       $"{item.WRBTR_BRUTTO:0.00}, " +            //WRBTR_BRUTTO
                       $"{item.MWSKZ}, " +            //MWSKZ
                       $"{item.MWSTS}, " + //MWSTS
                       $"{item.WMWST}, " + //WMWST
                       $"{item.KOSTL}, " + //KOSTL
                       $"{item.AUFNR}, " + //AUFNR
                       $"{item.MENGE}, " + //MENGE
                       $"{item.MEINS}, " + //MEINS
                       $"{item.PERNR}, " + //PERNR
                       $"{item.GSBER}, " + //GSBER
                       $"{item.PRCTR}, " + //PRCTR
                       $"{item.VBUND}, " + //VBUND
                       $"{item.BEWAR}, " + //BEWAR
                       $"{item.FKBER}, " + //FKBER
                       $"{item.XREF1}, " + //XREF1
                       $"{item.XREF2}, " + //XREF2
                       $"{item.XREF3}, " + //XREF3
                       $"{item.ZFBDT}, " + //ZFBDT
                       $"{item.BVTYP}, " + //BVTYP
                       $"{item.ZLSCH}, " + //ZLSCH
                       $"{item.ZTERM}, " + //ZTERM
                       $"{item.ZLSPR}, " + //ZLSPR
                       $"{item.PROJK}, " + //PROJK
                       $"{item.BARCD}"; //BARCD
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
    }
}
