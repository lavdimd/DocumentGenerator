using Microsoft.EntityFrameworkCore;
using SAP.Core.Models;
using SAP.Persistence.Models;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class StaticSettingService : IStaticSettingService
    {
        EcommerceClientContext _context = new();

        public async Task<StaticSetting> GetSetting(string key, int storeId = 1)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            var result = await _context.StaticSettings.Where(x => x.Name.Equals(key) && x.Deleted == false).FirstOrDefaultAsync(default);

            return result;
        }
    }
}
