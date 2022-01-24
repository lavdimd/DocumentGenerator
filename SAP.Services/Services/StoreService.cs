using Microsoft.EntityFrameworkCore;
using SAP.Core.Common.Constants;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Helpers;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class StoreService : IStoreService
    {

        #region Properties

        EcommerceClientContext _context = new();
        private readonly ILogService _logService;

        #endregion

        #region Ctor

        public StoreService(ILogService logService)
        {
            _logService = logService;
        }

        #endregion


        #region Methods

        #endregion

        public async Task<Response<Store>> GetMainStore(CancellationToken cancellationToken)
        {
            try
            {
                var mainStore = (await _context.Stores.Where(x => x.IsMainStore && x.Deleted == false).FirstOrDefaultAsync(cancellationToken: cancellationToken));

                return new Response<Store>(mainStore);
            }
            catch (Exception ex)
            {
                await _logService.AddLogAsync(
                  logLevel: LogLevelConstants.SapApiError,
                  shortMessage: $"Something went wrong on method: {MethodNameHelper.GetMethodName()}",
                  fullMessage: $"Full error information for error on method: {MethodNameHelper.GetMethodName()} /n" +
                  $"Exception Message: {ex.Message} /n " +
                  $"Inner Exception: {ex.InnerException?.Message}",
                  cancellationToken);

                return new Response<Store>(null, message: "Something went wrong!. Please see the Log table for more detailed exception.", statusCode: (int)HttpStatusCode.BadRequest);
            }
          
        }
    }
}
