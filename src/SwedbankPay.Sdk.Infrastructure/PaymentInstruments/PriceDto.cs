namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PriceDto
    {
        public PriceDto()
        {
        }

        public PriceDto(IPrice item)
        {
            Amount = item.Amount.InLowestMonetaryUnit;
            Type = item.Type.ToString();
            VatAmount = item.VatAmount.InLowestMonetaryUnit;
        }

        public long Amount { get; set; }

        public long VatAmount { get; set; }

        public string Type { get; set; }
    }
}