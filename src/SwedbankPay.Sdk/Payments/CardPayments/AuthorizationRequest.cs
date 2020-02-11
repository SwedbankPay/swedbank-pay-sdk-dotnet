namespace SwedbankPay.Sdk.Payments.Card
{
    public class AuthorizationRequest
    {
        public AuthorizationRequest(string cardNumber,
                                    int cardExpiryMonth,
                                    int cardExpiryYear,
                                    string cardVerificationCode = null,
                                    string cardHolderName = null)
        {
            Transaction = new AuthorizationRequestTransaction(cardNumber, cardExpiryMonth, cardExpiryYear, cardVerificationCode, cardHolderName);
        }


        public AuthorizationRequestTransaction Transaction { get; }
    }
}