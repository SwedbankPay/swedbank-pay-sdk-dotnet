namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentCancelTransactionDto
{
    public CardPaymentCancelTransactionDto(CardPaymentCancelTransaction transaction)
    {
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
    }

    public string Description { get; }

    public string PayeeReference { get; }
}