namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentReversalTransaction
    {
        Amount Amount { get; }
        string Description { get; }
        string PayeeReference { get; }
        Amount VatAmount { get; }
    }
}