using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAP.Core.Configuration;
using SAP.Core.Enum;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Models.Response;
using SAP.Persistence.Models;
using SAP.Services.Helpers.Interfaces;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP.Services.Services
{
    public class DocumentGeneratorService : IDocumentGeneratorService
    {
        readonly EcommerceClientContext _context = new();

        private readonly ITransactionHistoryService _transactionHistoryService;
        private readonly IConfiguration _configuration;
        readonly AppSettings _appSettings;
        private readonly IDocumentGeneratorHelper _documentGeneratorHelper;


        public DocumentGeneratorService(
            ITransactionHistoryService transactionHistoryService,
            IConfiguration configuration,
            AppSettings appSettings,
            IDocumentGeneratorHelper documentGeneratorHelper)
        {
            _transactionHistoryService = transactionHistoryService;
            _configuration = configuration;
            _appSettings = appSettings;
            _documentGeneratorHelper = documentGeneratorHelper;
        }

        public async Task<Response<string>> ReportDeferredRevenues(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            var preparedData = await _documentGeneratorHelper.PrepareDeferredRevenuesWithinTimePeriod(transactionRequestModel, cancellationToken);

            if (preparedData.Data == null)
            {
                return new Response<string>(null);
            }

            var prepareCSVForActualRevenues = await _documentGeneratorHelper.PrepareCSVFile(preparedData.Data);

            return new Response<string>(prepareCSVForActualRevenues.Data);
        }

        public async Task<Response<string>> ReportActualRevenues(TransactionRequestModel transactionRequestModel, CancellationToken cancellationToken)
        {
            var preparedData = await _documentGeneratorHelper.PrepareActualRevenuesWithinTimePeriod(transactionRequestModel, cancellationToken);

            if (preparedData.Data == null)
            {
                return new Response<string>(null);
            }

            var prepareCSVForActualRevenues = await _documentGeneratorHelper.PrepareCSVFile(preparedData.Data);

            return new Response<string>(prepareCSVForActualRevenues.Data);
        }

        public async Task<Response<List<SapInterfaceModel>>> PrepareTransactionHistoryForSpecificTimePeriods(TransactionRequestModel request, CancellationToken cancellationToken)
        {

            return new Response<List<SapInterfaceModel>>(new List<SapInterfaceModel>());
        }

        public async Task<Response<bool>> UploadCsvToFtp(string csvFile, CancellationToken cancellationToken)
        {
            var dateNow = DateTime.Now.Date;
            var ftpServerConfig = GetFtpServerConfigurations();
            try
            {
                MakeFTPDirectoryIfNotExist(ftpServerConfig);

                FtpWebRequest request = (FtpWebRequest)WebRequest
                                        .Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", ftpServerConfig?.Host, ftpServerConfig?.Directory, $"EXAMPLE_Invoice-Customer_{dateNow.Day}-{dateNow.Month}-{dateNow.Year}.txt")));
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.EnableSsl = false;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(ftpServerConfig?.Username, ftpServerConfig?.Password);

                byte[] fileContents = Encoding.UTF8.GetBytes(csvFile);
                request.ContentLength = fileContents.Length;

                using Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                //await _httpLogService.PostLogAsync(
                //  LogLevelConstants.SapApiError,
                //  shortMessage: $"Failed to upload data to the ftp server!",
                //  fullMessage: $"Message: {ex?.Message?.ToString()} /n Inner Exception: {ex?.InnerException?.ToString()}",
                //  cancellationToken);

                return new Response<bool>(false, message: $"Failed to upload. Exception: {ex.Message}");
            }
        }

        private void MakeFTPDirectoryIfNotExist(FtpServerConfig ftpServerConfig)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            string[] subDirs = ftpServerConfig.Directory.Split('/');

            string currentDir = string.Format("ftp://{0}", ftpServerConfig.Host);

            foreach (string subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpServerConfig.Username, ftpServerConfig.Password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {
                    //directory already exist
                }
            }
        }

        private FtpServerConfig GetFtpServerConfigurations()
        {
            var app = _appSettings.FtpServerConfig;
            //FtpServerConfig ftpServerConfig = new FtpServerConfig
            //{
            //    Host = "am.gjirafamall.com",
            //    Username = "am.gjirafamall.com|am",
            //    Password = "6UWcEufu",
            //    Port = 21
            //};

            FtpServerConfig ftpServerConfig = new FtpServerConfig
            {
                Directory = "sapftp/CZ01/FLEA_MARKET/TEST",
                Host = "﻿ftp.cncenter.cz",
                Username = "fleamarket",
                Password = "Fl@mkt@5196",
                Port = 21
            };
            return ftpServerConfig;
        }
    }
}
