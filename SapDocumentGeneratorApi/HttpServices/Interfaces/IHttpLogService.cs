using SapDocumentGeneratorApi.Models.Logs;
using SapDocumentGeneratorApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.HttpServices.Interfaces
{
    public interface IHttpLogService
    {
        public Task<Response<Log>> PostLogAsync(int logLevel, string shortMessage, string fullMessage = "", CancellationToken cancellationToken = default);
    }
}
