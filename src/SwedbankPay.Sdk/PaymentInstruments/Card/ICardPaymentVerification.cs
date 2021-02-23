namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentVerification : IIdentifiable
    {
        string CardBrand { get; }
        string CardType { get; }
        string PaymentToken { get; }
        string RecurrenceToken { get; }
        string MaskedPan { get; }
        string ExpiryDate { get; }
        string PanToken { get; }
        ITransaction Transaction { get; }
    }
}