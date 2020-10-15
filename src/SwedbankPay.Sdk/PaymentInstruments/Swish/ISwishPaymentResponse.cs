namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public interface ISwishPaymentResponse
    {
        ISwishPaymentOperations Operations { get; }
        ISwishPayment Payment { get; }
    }
}