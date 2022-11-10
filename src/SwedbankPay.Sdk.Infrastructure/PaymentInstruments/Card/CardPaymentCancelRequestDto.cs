namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentCancelRequestDto
{
    public CardPaymentCancelRequestDto(CardPaymentCancelRequest payload)
    {
        Transaction = new CardPaymentCancelTransactionDto(payload.Transaction);
    }

    public CardPaymentCancelTransactionDto Transaction { get; }
}