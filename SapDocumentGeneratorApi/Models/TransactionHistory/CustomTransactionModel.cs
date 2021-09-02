using SapDocumentGeneratorApi.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.TransactionHistory
{
    public class CustomTransactionModel
    {
        #region Customer
        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the language identifier for the customer using header parameter 'languageid'
        /// </summary>
        public string CustomerLanguage { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier for the customer using header parameter 'currencycode'
        /// </summary>
        public string Currency { get; set; }

        #endregion

        public decimal Amount { get; set; }

        #region BoostingPlan

        public string BoostPlanName { get; set; }
        public string BoostPlanDescription { get; set; }
        public int BoostPlanDurationInDays { get; set; }

        #endregion

        #region Payment

        public long PaymentId { get; set; }
        public string CardIssuerBank { get; set; }
        public string CardBrand { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public PaymentStateEnum PaymentStatus { get; set; }
        #endregion

    }
}
