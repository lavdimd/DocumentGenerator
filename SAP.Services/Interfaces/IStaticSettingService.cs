using SAP.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Interfaces
{
    public interface IStaticSettingService
    {
        Task<StaticSetting> GetSetting(string key, int storeId = 1);

    }
}
