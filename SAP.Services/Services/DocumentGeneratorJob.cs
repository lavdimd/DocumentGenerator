using SAP.Models.DTOs.Request.Transactions;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class DocumentGeneratorJob : IDocumentGeneratorJob
    {
        private IDocumentGeneratorService _documentGeneratorService;

        public DocumentGeneratorJob(
            IDocumentGeneratorService documentGeneratorService )
        {
            _documentGeneratorService = documentGeneratorService;
        }

        public async Task GenerateCSV(CancellationToken cancellationToken)
        {
            var transactionRequesteModel = new TransactionRequestModel()
            {
                DateFrom = DateTime.Now.Date.AddMonths(-1),
                DateTo = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59)
            };

            var preparedData  = await _documentGeneratorService.PrepareTransactionHistoryForSpecificTimePeriods(transactionRequesteModel, cancellationToken);
             
            if(preparedData.Data != null)
            {
                //var response = await _documentGeneratorService.GenerateAndUploadCsvToFtp(preparedData.Data, cancellationToken);
            }

        }
    }
}
