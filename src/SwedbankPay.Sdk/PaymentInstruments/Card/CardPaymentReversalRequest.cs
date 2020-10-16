using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentReversalRequest
    {
        public Amount Amount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
        public Amount VatAmount { get; set; }
    }
}