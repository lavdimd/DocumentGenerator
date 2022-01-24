using Microsoft.EntityFrameworkCore;
using SAP.Core.Common.Constants;
using SAP.Core.Models;
using SAP.Persistence.Models;
using SAP.Services.Helpers;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class StaticSettingService : IStaticSettingService
    {
        EcommerceClientContext _context = new();
        private readonly ILogService _logService;

        public StaticSettingService(ILogService logService)
        {
            _logService = logService;
        }

        public async Task<StaticSetting> GetSetting(string key, int storeId = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return null;

                var result = await _context.StaticSettings.Where(x => x.Name.Equals(key) && x.Deleted == false).FirstOrDefaultAsync(default);

                return result;
            }
            catch (Exception ex)
            {
                await _logService.AddLogAsync(
                  logLevel: LogLevelConstants.SapApiError,
                  shortMessage: $"Something went wrong on method: {MethodNameHelper.GetMethodName()}",
                  fullMessage: $"Full error information for error on method: {MethodNameHelper.GetMethodName()} /n" +
                  $"Exception Message: {ex.Message} /n " +
                  $"Inner Exception: {ex.InnerException?.Message}",
                  default);

                return null;
            }
           
        }
    }
}
