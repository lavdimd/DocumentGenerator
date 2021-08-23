using SapDocumentGeneratorApi.Enum;
using SapDocumentGeneratorApi.Models.Payment;

namespace SapDocumentGeneratorApi.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public long PaymentId { get; set; }
        public string State { get; set; }
        public decimal Amount { get; set; }
        public string CardIssuerBank { get; set; }
        public string CardBrand { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public string AccountNumber { get; set; }
        public string AdditionalParams { get; set; }
        public PaymentStateEnum PaymentStatusEnum { get; set; }
        public int? ParentTablePaymentId { get; set; }
        public PaymentInfoDto PaymentInfo { get; set; }
    }
}
