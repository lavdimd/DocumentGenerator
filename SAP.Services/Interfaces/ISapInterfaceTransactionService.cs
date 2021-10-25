using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Interfaces
{
    public interface ISapInterfaceTransactionService
    {
        Task<Response<SapInterfaceTransaction>> Add(SapInterfaceModel model, TransactionRequestModel requestModel, CancellationToken canellactionToken);
    }
}
