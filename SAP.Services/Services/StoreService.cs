using Microsoft.EntityFrameworkCore;
using SAP.Models.Response;
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
    public class StoreService : IStoreService
    {

        #region Properties

        EcommerceClientContext _context = new();

        #endregion

        #region Ctor

        #endregion


        #region Methods

        #endregion

        public async Task<Response<Store>> GetMainStore(CancellationToken cancellationToken)
        {
            var mainStore = (await _context.Stores.Where(x => x.IsMainStore && x.Deleted == false).FirstOrDefaultAsync(cancellationToken: cancellationToken));

            return new Response<Store>(mainStore);
        }
    }
}
