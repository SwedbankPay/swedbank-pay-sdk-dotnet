namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentResonseDto
    {
        public TrustlyPaymentDto Payment { get; set; }
        public OperationListDto Operations { get; set; }
    }
}