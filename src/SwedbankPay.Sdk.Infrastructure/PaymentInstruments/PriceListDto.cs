namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PriceListDto
    {
        public string Type { get; set; }
        public long Amount { get; set; }
        public long VatAmount { get; set; }
    }
}