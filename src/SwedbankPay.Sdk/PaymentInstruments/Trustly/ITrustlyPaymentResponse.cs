namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPaymentResponse
    {
        /// <summary>
        /// Details about the current Trustly payment.
        /// </summary>
        public ITrustlyPayment Payment { get; set; }

        /// <summary>
        /// Currently available operations on the current Trustly payment.
        /// </summary>
        public ITrustlyPaymentOperations Operations { get; set; }
    }
}