namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentReversalRequest
    {
        Amount Amount { get; }
        string Description { get; }
        string PayeeReference { get; }
        Amount VatAmount { get; }
    }
}