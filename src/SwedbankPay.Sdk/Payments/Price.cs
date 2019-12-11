namespace SwedbankPay.Sdk.Payments
{
    public class Price
    {
        public long? Amount { get; set; }
        public PriceType Type { get; set; }
        public long? VatAmount { get; set; }
    }
}