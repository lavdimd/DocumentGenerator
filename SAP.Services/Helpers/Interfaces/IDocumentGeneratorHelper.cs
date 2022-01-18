using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Helpers.Interfaces
{
    public interface IDocumentGeneratorHelper
    {
        Task<Response<List<SapInterfaceModel>>> PrepareDeferredRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PreparePaymentsWithinSpecificPeriodWhenDeferredRevenuesExist(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareActualRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareRegularRevenuesWithVATCreditRevenues(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareActualRevenuesFromDeferredRevenuesCreditRevenues(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareRevenuesFromRegularAndDeferredDebitDeferredRevenues(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareRevenuesFromDeferredDebitDeferredRevenues(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<List<SapInterfaceModel>>> PrepareAllRevenuesWithinTimePeriod(TransactionRequestModel request, CancellationToken cancellationToken);
        Task<Response<string>> PrepareCSVFile(List<SapInterfaceModel> sapInterfaceModels);
        Task<Response<string>> GenerateCSVHeader(Type type);
        public string GenerateReferenceNumber();
    }
}
