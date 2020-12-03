namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PriceListDto
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
    }
}