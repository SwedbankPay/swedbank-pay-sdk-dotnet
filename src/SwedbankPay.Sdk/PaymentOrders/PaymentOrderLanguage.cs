namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderLanguage : TypeSafeEnum<PaymentOrderLanguage>
    {
        public static readonly PaymentOrderLanguage Swedish = new PaymentOrderLanguage(nameof(Swedish), "sv-SE");
        public static readonly PaymentOrderLanguage Norwegian = new PaymentOrderLanguage(nameof(Norwegian), "nb-NO");
        public static readonly PaymentOrderLanguage English = new PaymentOrderLanguage(nameof(English), "en-US");


        public PaymentOrderLanguage(string name, string value)
            : base(name, value)
        {
        }
    }
}