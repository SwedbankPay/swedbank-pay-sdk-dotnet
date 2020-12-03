namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class PriceDto
    {
        public int Amount { get; set; }
        public string Type { get; set; }
        public int VatAmount { get; set; }
    }
}