﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public FtpServerConfig FtpServerConfig { get; set; } = new FtpServerConfig();
    }
}