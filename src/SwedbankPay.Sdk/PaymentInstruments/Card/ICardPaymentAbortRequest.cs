namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAbortRequest
    {
        ICardPaymentAbortPayment Payment { get; }
    }
}