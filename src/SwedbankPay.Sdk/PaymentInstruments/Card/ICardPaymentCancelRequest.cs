namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentCancelRequest
    {
        string Description { get; }
        string PayeeReference { get; }
        ICardPaymentCancelTransaction Transaction { get; }
    }
}