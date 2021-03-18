namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    internal class TrustlyPaymentResonseDto
    {
        public TrustlyPaymentDto Payment { get; set; }
        public OperationListDto Operations { get; set; }
    }
}