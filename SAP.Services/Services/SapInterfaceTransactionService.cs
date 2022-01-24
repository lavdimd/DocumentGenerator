using AutoMapper;
using SAP.Core.Common.Constants;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Helpers;
using SAP.Services.Interfaces;
using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class SapInterfaceTransactionService : ISapInterfaceTransactionService
    {
        #region Properties

        private EcommerceClientContext _context = new();
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        #endregion

        #region Ctor

        public SapInterfaceTransactionService(
            IMapper mapper,
            ILogService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        #endregion


        #region Methods

        public async Task<Response<SapInterfaceTransaction>> Add(SapInterfaceModel model, TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                var mapData = _mapper.Map<SapInterfaceTransaction>(model);
                mapData.DateFrom = requestModel.DateFrom;
                mapData.DateTo = requestModel.DateTo;
                var addedData = await _context.SapInterfaceTransactions.AddAsync(mapData, cancellationToken);

                if (await _context.SaveChangesAsync() <= 0)
                {
                    return new Response<SapInterfaceTransaction>(null, message: "Error in database!", statusCode: (int)HttpStatusCode.BadRequest);
                }

                return new Response<SapInterfaceTransaction>(mapData);
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

                return new Response<SapInterfaceTransaction>(null, message: "Something went wrong!. Please see the Log table for more detailed exception.", statusCode: (int)HttpStatusCode.BadRequest);
            }
        }

        #endregion

    }
}
