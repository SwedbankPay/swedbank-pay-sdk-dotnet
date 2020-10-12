namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationRequest : ICardPaymentAuthorizationRequest
    {
        public CardPaymentAuthorizationRequest(string cardNumber,
                                    int cardExpiryMonth,
                                    int cardExpiryYear,
                                    string cardVerificationCode = null,
                                    string cardHolderName = null)
        {
            Transaction = new CardPaymentAuthorizationRequestTransaction(cardNumber, cardExpiryMonth, cardExpiryYear, cardVerificationCode, cardHolderName);
        }


        public CardPaymentAuthorizationRequestTransaction Transaction { get; }
    }
}