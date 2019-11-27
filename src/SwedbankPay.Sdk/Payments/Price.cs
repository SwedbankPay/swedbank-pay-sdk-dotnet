namespace SwedbankPay.Sdk.Payments
{
    public class Price
    {
        public PriceType Type { get; set; }
        public long? Amount { get; set; }
        public long? VatAmount { get; set; }
    }
}