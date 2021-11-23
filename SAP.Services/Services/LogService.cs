using SAP.Persistence.Models;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class LogService : ILogService
    {
        #region Properties

        readonly EcommerceClientContext _context = new();

        #endregion

        #region Methods

        public async Task<Log> AddLogAsync(int logLevel, string shortMessage, string fullMessage = "", CancellationToken cancellationToken = default)
        {
            var logToAdd = new Log
            {
                LogLevelId = (int)logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = "",
                PageUrl = "",
                ReferrerUrl = "",
                CreatedOn = DateTime.Now,
            };

            var addedData = await _context.Logs.AddAsync(logToAdd, cancellationToken);

            if (await _context.SaveChangesAsync() <= 0)
            {
                return null;
            }

            return logToAdd;
        }

        #endregion
    }
}
