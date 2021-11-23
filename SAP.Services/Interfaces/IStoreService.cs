using SAP.Models.Response;
using SAP.Persistence.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Interfaces
{
    public interface IStoreService
    {
        Task<Response<Store>> GetMainStore(CancellationToken cancellationToken);
    }
}
