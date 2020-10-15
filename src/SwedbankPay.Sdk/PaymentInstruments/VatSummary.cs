namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class VatSummary
    {
        public VatSummary(Amount amount,
                          string vatPercent,
                          Amount vatAmount)
        {
            Amount = amount;
            VatPercent = vatPercent;
            VatAmount = vatAmount;
        }

        public Amount Amount { get; }
        public string VatPercent { get; set; }
        public Amount VatAmount { get; }

    }
}
