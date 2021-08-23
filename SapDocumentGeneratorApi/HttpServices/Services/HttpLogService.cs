using Newtonsoft.Json;
using SapDocumentGeneratorApi.Constants;
using SapDocumentGeneratorApi.Endpoints;
using SapDocumentGeneratorApi.HttpServices.Interfaces;
using SapDocumentGeneratorApi.Models.Logs;
using SapDocumentGeneratorApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.HttpServices.Services
{
    public class HttpLogService : IHttpLogService
    {
        private readonly HttpClient _httpClient;
        public HttpLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<Log>> PostLogAsync(int logLevel, string shortMessage, string fullMessage = "", CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = $"{LogAPIEndpoints.PostLog}";

                LogDto logDto  = new LogDto
                {
                    LogLevel = logLevel,
                    shortMessage = shortMessage,
                    fullMessage = fullMessage
                };

                var jsonLogRequest = JsonConvert.SerializeObject(logDto);
                var content = new StringContent(jsonLogRequest, Encoding.UTF8, "application/json");

                var responseFromLogService = await _httpClient.PostAsync(endpoint, content, cancellationToken);

                if (responseFromLogService == null)
                {
                    return new Response<Log>(null, false, "Log failed to be inserted", (int)HttpStatusCode.BadRequest);
                }

                if (responseFromLogService.StatusCode != HttpStatusCode.OK)
                {
                    return new Response<Log>(null, false, "Log failed to be inserted", (int)HttpStatusCode.BadRequest);
                }

                var contentResponseAsString = await responseFromLogService.Content.ReadAsStringAsync();

                Response<Log> deserializedResponse = JsonConvert.DeserializeObject<Response<Log>>(contentResponseAsString);

                return deserializedResponse;

            }
            catch (Exception ex)
            {
                return new Response<Log>(null, false);
            }
        }
    }
}
