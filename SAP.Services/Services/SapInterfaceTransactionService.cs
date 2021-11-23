using AutoMapper;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class SapInterfaceTransactionService : ISapInterfaceTransactionService
    {
        #region Properties

        private EcommerceClientContext _context = new();
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public SapInterfaceTransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion


        #region Methods

        public async Task<Response<SapInterfaceTransaction>> Add(SapInterfaceModel model, TransactionRequestModel requestModel, CancellationToken canellactionToken)
        {
            var mapData = _mapper.Map<SapInterfaceTransaction>(model);
            mapData.DateFrom = requestModel.DateFrom;
            mapData.DateTo = requestModel.DateTo;
            var addedData = await _context.SapInterfaceTransactions.AddAsync(mapData, canellactionToken);

            if (await _context.SaveChangesAsync() <= 0)
            {
                return new Response<SapInterfaceTransaction>(null, message: "Error in database!", statusCode: (int)HttpStatusCode.BadRequest);
            }

            return new Response<SapInterfaceTransaction>(mapData);
        }

        #endregion

    }
}
