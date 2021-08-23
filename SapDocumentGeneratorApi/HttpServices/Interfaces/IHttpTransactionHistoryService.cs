using SapDocumentGeneratorApi.Models;
using SapDocumentGeneratorApi.Models.Response;
using SapDocumentGeneratorApi.Models.TransactionHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.HttpServices.Interfaces
{
    public interface IHttpTransactionHistoryService
    {
        Task<Response<IList<CustomTransactionModel>>> GetTransactionHistory(TransactionRequestModel requestModel, CancellationToken cancellationToken);
    }
}
