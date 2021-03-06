using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SAP.Core.Common.Constants;
using SapDocumentGeneratorApi.Endpoints;
using SapDocumentGeneratorApi.HttpServices.Interfaces;
using SapDocumentGeneratorApi.Models;
using SapDocumentGeneratorApi.Models.Response;
using SapDocumentGeneratorApi.Models.TransactionHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.HttpServices.Services
{
    public class HttpTransactionHistoryService : IHttpTransactionHistoryService
    {
        #region Properties
        private const string APIKEYNAME = "X-API-Key";
        private readonly IHttpLogService _httpLogService;
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;
        #endregion

        #region Ctor

        public HttpTransactionHistoryService(
            IHttpLogService httpLogService,
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _httpLogService = httpLogService;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<Response<IList<CustomTransactionModel>>> GetTransactionHistory(TransactionRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                var endpoint = $"{TransactionHistoryEndpoints.GetTransactions}";

                //using var client = new HttpClient();

                var apiKeyString = _configuration.GetValue<string>(APIKEYNAME);
                _httpClient.DefaultRequestHeaders.Add(APIKEYNAME, apiKeyString);
                var jsonRequest = JsonConvert.SerializeObject(requestModel);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var responseFromExternalService = await _httpClient.PostAsync(endpoint, content, cancellationToken);

                if (responseFromExternalService == null)
                {
                    return new Response<IList<CustomTransactionModel>>(null, false, "Failed to load data", (int)HttpStatusCode.BadRequest);
                }
                if(responseFromExternalService.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new Response<IList<CustomTransactionModel>>(null, false, "Unauthorized access", (int)HttpStatusCode.Unauthorized);
                }
                if (responseFromExternalService.StatusCode != HttpStatusCode.OK)
                {
                    return new Response<IList<CustomTransactionModel>>(null, false, "Failed to load data from external service", (int)HttpStatusCode.BadRequest);
                }

                var contentResponseAsString = await responseFromExternalService.Content.ReadAsStringAsync();

                Response<IList<CustomTransactionModel>> deserializedResponse = JsonConvert.DeserializeObject<Response<IList<CustomTransactionModel>>>(contentResponseAsString);

                return deserializedResponse;
            }
            catch (Exception ex)
            {
                await _httpLogService.PostLogAsync(
                    LogLevelConstants.SapApiError,
                    shortMessage: $"Failed to connect with TransactionHistory API",
                    fullMessage: $"Message: {ex?.Message} /n InnerException: { ex?.InnerException?.ToString()}",
                    cancellationToken);

                return new Response<IList<CustomTransactionModel>>(null, false);
            }
        }

        public async Task<Response<TransactionUpdateResponseModel>> UpdateTransactionHistoryStatus(TransactionUpdateRequestModel requestModel, CancellationToken cancellationToken)
        {
            try
            {
                var endpoint = $"{TransactionHistoryEndpoints.UpdateTransactions}";

                using var client = new HttpClient();

                var apiKeyString = _configuration.GetValue<string>(APIKEYNAME);
                client.DefaultRequestHeaders.Add(APIKEYNAME, apiKeyString);
                var jsonRequest = JsonConvert.SerializeObject(requestModel);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var responseFromExternalService = await client.PutAsync(endpoint, content, cancellationToken);

                if (responseFromExternalService == null)
                {
                    return new Response<TransactionUpdateResponseModel>(null, false, "Failed to update statuses in TransactionHistory", (int)HttpStatusCode.BadRequest);
                }
                if (responseFromExternalService.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new Response<TransactionUpdateResponseModel>(null, false, "Unauthorized access", (int)HttpStatusCode.Unauthorized);
                }
                if (responseFromExternalService.StatusCode != HttpStatusCode.OK)
                {
                    return new Response<TransactionUpdateResponseModel>(null, false, "Failed to update statuses in TransactionHistory", (int)HttpStatusCode.BadRequest);
                }

                var contentResponseAsString = await responseFromExternalService.Content.ReadAsStringAsync();

                Response<TransactionUpdateResponseModel> deserializedResponse = JsonConvert.DeserializeObject<Response<TransactionUpdateResponseModel>>(contentResponseAsString);

                return deserializedResponse;
            }
            catch (Exception ex)
            {
                await _httpLogService.PostLogAsync(
                   LogLevelConstants.SapApiError,
                   shortMessage: $"Failed to connect with TransactionHistory API",
                   fullMessage: $"Message: {ex?.Message} /n InnerException: { ex?.InnerException?.ToString()}",
                   cancellationToken);

                return new Response<TransactionUpdateResponseModel>(null, false);
            }
        }


        #endregion
    }
}
