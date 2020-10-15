namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentResponse
    {
        public IMobilePayPaymentOperations Operations { get; set; }
        public IMobilePayPayment Payment { get; set; }

    }
}