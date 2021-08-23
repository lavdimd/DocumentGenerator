using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.JobServices.Interfaces
{
    public interface ITransactionHistoryJob
    {
        Task PrepareReportsFromTrasactionHistory(CancellationToken cancellationToken);
    }
}
