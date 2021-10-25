using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Interfaces
{
    public interface IDocumentGeneratorService
    {
        Task<Response<string>> ReportDeferredRevenues(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken);
        Task<Response<string>> ReportActualRevenues(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareTransactionHistoryForSpecificTimePeriods(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<bool>> UploadCsvToFtp(string csvFile, CancellationToken cancellationToken);
    }
}
