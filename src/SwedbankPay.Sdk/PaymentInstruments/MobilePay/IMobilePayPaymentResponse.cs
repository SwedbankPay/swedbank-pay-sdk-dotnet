namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentResponse
    {
        /// <summary>
        /// The current payment and details about it.
        /// </summary>
        public IMobilePayPayment Payment { get; set; }

        /// <summary>
        /// The currently available operations of the payment.
        /// </summary>
        public IMobilePayPaymentOperations Operations { get; set; }

    }
}