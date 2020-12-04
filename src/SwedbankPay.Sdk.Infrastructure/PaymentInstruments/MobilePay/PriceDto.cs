namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class PriceDto
    {
        public PriceDto() { }

        public PriceDto(IPrice item)
        {
            Amount = item.Amount.InLowestMonetaryUnit;
            VatAmount = item.VatAmount.InLowestMonetaryUnit;
            Type = item.Type.ToString();
        }

        public long Amount { get; set; }
        public string Type { get; set; }
        public long VatAmount { get; set; }
    }
}