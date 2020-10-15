namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentResponse
    {
        public ITrustlyPayment Payment { get; set; }
        public ITrustlyPaymentOperations Operations { get; set; }
    }
}