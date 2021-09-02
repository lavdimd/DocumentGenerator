using Microsoft.Extensions.Configuration;
using SapDocumentGeneratorApi.Configuration;
using SapDocumentGeneratorApi.Constants;
using SapDocumentGeneratorApi.HttpServices.Interfaces;
using SapDocumentGeneratorApi.JobServices.Interfaces;
using SapDocumentGeneratorApi.Models;
using SapDocumentGeneratorApi.Models.TransactionHistory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.JobServices.Services
{
    public class TransactionHistoryJob : ITransactionHistoryJob
    {
        #region Properties

        private readonly IHttpTransactionHistoryService _httpTransactionHistoryService;
        private readonly IConfiguration _configuration;
        private readonly IHttpLogService _httpLogService;

        #endregion


        #region Ctor

        public TransactionHistoryJob(
          IHttpTransactionHistoryService httpTransactionHistoryService,
          IConfiguration configuration,
          IHttpLogService httpLogService)
        {
            _httpTransactionHistoryService = httpTransactionHistoryService;
            _configuration = configuration;
            _httpLogService = httpLogService;
        }

        #endregion


        #region Methods

        public async Task PrepareReportsFromTrasactionHistory(CancellationToken cancellationToken)
        {
            //gets data from last day
            var transactionRequestModel = new TransactionRequestModel()
            {
                DateFrom = DateTime.Now.Date.AddDays(-1),
                DateTo = DateTime.Now.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999)
            };

            var responseFromClient = await _httpTransactionHistoryService.GetTransactionHistory(transactionRequestModel, cancellationToken);

            if (!string.IsNullOrEmpty(responseFromClient.Message) && !responseFromClient.Succeeded)
            {
                await _httpLogService.PostLogAsync(
                        LogLevelConstants.SapApiError,
                        shortMessage: $"{responseFromClient.Message}",
                        fullMessage: $"Message: {responseFromClient.Message}",
                        cancellationToken);
            }

            if (responseFromClient.Data != null && responseFromClient.Data.Count > 0)
            {
                var isUploadSuccessfully = await UploadCSVToFtp(responseFromClient.Data, transactionRequestModel, cancellationToken);

                if(isUploadSuccessfully) 
                {
                    var transationHistoryIds = responseFromClient.Data.Select(x => x.Id).ToList();

                    var requestModel = new TransactionUpdateRequestModel
                    {
                        TransactionHistoryIds = transationHistoryIds,
                        TransactionRequestModel = transactionRequestModel
                    };

                    var responseFromUpdateExternal = await _httpTransactionHistoryService.UpdateTransactionHistoryStatus(requestModel, cancellationToken);

                    if (!string.IsNullOrEmpty(responseFromClient.Message) && responseFromClient.Data == null)
                    {
                        await _httpLogService.PostLogAsync(
                                LogLevelConstants.SapApiError,
                                shortMessage: $"{responseFromClient.Message}",
                                fullMessage: $"Message: {responseFromClient.Message}",
                                cancellationToken);
                    }
                }
            }
        }

        private async Task<bool> UploadCSVToFtp(IList<CustomTransactionModel> responseFromClient, TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            var csv = GenerateCSV(typeof(CustomTransactionModel), responseFromClient);

            var ftpServerConfig = GetFtpServerConfigurations();
            var dateSimplified = transactionRequestModel.DateFrom.Value.Date;
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest
                                        .Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", ftpServerConfig?.Host, "Ecommerce", "RevenuesForDate-" + dateSimplified.Day + "-" + dateSimplified.Month + "-" + dateSimplified.Year + ".txt")));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.EnableSsl = false;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(ftpServerConfig?.Username, ftpServerConfig?.Password);

                byte[] fileContents = Encoding.UTF8.GetBytes(csv);
                request.ContentLength = fileContents.Length;

                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                await _httpLogService.PostLogAsync(
                    LogLevelConstants.SapApiError,
                    shortMessage: $"Failed to upload data to the ftp server!",
                    fullMessage: $"Message: {ex?.Message?.ToString()} /n Inner Exception: {ex?.InnerException?.ToString()}",
                    cancellationToken);
            }

            return false;
        }

        private string GenerateCSV(Type type, IList<CustomTransactionModel> data)
        {
            string csv = "";

            foreach (var prop in type.GetProperties())
            {
                if (prop.Name != "Id")
                {
                    if (csv.Length == 0)
                    { 
                        csv += $"{prop.Name}"; 
                    }
                    else
                    { 
                        csv += $", {prop.Name}"; 
                    }
                }
              
            }
            csv += Environment.NewLine;

            foreach (var item in data)
            {
                csv += $"{item.CustomerGuid}, {item.Username}, " +
                       $"{item.FullName}, {item.Email}, " +
                       $"{item.CustomerLanguage}, {item.Currency}, " +
                       $"{item.Amount}, {item.BoostPlanName}, " +
                       $"{item.BoostPlanDescription}, {item.BoostPlanDurationInDays}, " +
                       $"{item.PaymentId}, {item.CardIssuerBank}, " +
                       $"{item.CardBrand}, {item.CardNumber}, " +
                       $"{item.CardExpiration}, {item.PaymentStatus} {Environment.NewLine}";
            }

            return csv;
        }

        private FtpServerConfig GetFtpServerConfigurations()
        {
            FtpServerConfig ftpServerConfig = _configuration.GetSection(nameof(FtpServerConfig))
                                                 .Get<FtpServerConfig>();

            return ftpServerConfig;
        }

        #endregion

    }
}
