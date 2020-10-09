using SwedbankPay.Sdk.Payments.CardPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface ICardPaymentResponse
    {
        ICardPayment Payment { get; }
        ICardPaymentOperations Operations { get; }
    }
}