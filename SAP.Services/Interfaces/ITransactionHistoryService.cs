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
    public interface ITransactionHistoryService
    {
        Task<Response<List<CustomTransactionSummaryModel>>> GetActualRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<Response<List<CustomTransactionSummaryModel>>> GetFromDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken);
        Task<Response<List<CustomTransactionSummaryModel>>> GetDeferredRevenuesWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken);
        Task<Response<List<CustomTransactionSummaryModel>>> GetAllPaymentsWithinSpecificPeriod(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken);


    }
}
