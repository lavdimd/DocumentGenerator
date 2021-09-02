using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.TransactionHistory
{
    public class TransactionUpdateRequestModel
    {
        public List<int> TransactionHistoryIds { get; set; }
        public TransactionRequestModel TransactionRequestModel { get; set; }

    }
}
