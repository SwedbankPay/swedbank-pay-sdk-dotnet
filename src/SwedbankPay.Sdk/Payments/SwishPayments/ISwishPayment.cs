using SwedbankPay.Sdk.Payments.SwishPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface ISwishPayment
    {
        ISwishPaymentOperations Operations { get; }
        SwishPaymentResponseObject PaymentResponse { get; }
    }
}