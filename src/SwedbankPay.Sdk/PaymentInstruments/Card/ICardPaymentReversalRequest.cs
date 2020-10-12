namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentReversalRequest
    {
        Amount Amount { get; }
        string Description { get; }
        string PayeeReference { get; }
        ICardPaymentReversalTransaction Transaction { get; set; }
        Amount VatAmount { get; }
    }
}