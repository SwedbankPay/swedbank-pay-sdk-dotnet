using SwedbankPay.Sdk.Payments.CardPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface ICardPayment
    {
        ICardPaymentOperations Operations { get; }
        PaymentResponseObject PaymentResponse { get; }
    }
}