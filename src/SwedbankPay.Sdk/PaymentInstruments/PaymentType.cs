namespace SwedbankPay.Sdk.PaymentInstruments
{
    public sealed class PaymentType : TypeSafeEnum<PaymentType, string>
    {
        public static readonly PaymentType CreditCard = new PaymentType(nameof(CreditCard), "creditcard");
        public static readonly PaymentType Swish = new PaymentType(nameof(Swish), "swish");
        public static readonly PaymentType Vipps = new PaymentType(nameof(Vipps), "vipps");
        public static readonly PaymentType DirectDebit = new PaymentType(nameof(DirectDebit), "directdebit");


        private PaymentType(string name, string value)
            : base(name, value)
        {
        }
    }
}