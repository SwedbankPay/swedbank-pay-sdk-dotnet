namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobilePayPaymentResponse
    {
        IOperationList Operations { get; }
        IMobilePayPaymentResponse Payment { get; }
    }
}