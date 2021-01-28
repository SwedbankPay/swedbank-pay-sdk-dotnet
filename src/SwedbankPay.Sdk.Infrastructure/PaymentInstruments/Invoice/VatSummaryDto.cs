namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class VatSummaryDto
    {
        public VatSummaryDto(VatSummary item)
        {
            Amount = item.Amount.InLowestMonetaryUnit;
            VatPercent = item.VatPercent;
            VatAmount = item.VatAmount.InLowestMonetaryUnit;
        }

        public long Amount { get; set; }

        public string VatPercent { get; set; }

        public long VatAmount { get; set; }
    }
}