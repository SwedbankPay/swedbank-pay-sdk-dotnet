namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentReversalRequestDto
{
    public CardPaymentReversalRequestDto(CardPaymentReversalRequest payload)
    {
        Transaction = new CardPaymentReversalTransactionDto(payload.Transaction);
    }

    public CardPaymentReversalTransactionDto Transaction { get; }
}