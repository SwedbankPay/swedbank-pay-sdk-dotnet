namespace SwedbankPay.Sdk.Payments.Card
{
    public class AuthorizationRequest
    {
        public AuthorizationRequest(string cardNumber, int cardExpiryMonth, int cardExpiryYear, string cardVerificationCode = null, string cardHolderName = null)
        {
            Transaction = new AuthorizationTransaction(cardNumber, cardExpiryMonth, cardExpiryYear, cardVerificationCode, cardHolderName);
        }

        public AuthorizationTransaction Transaction { get; }

        public class AuthorizationTransaction
        {
            protected internal AuthorizationTransaction(string cardNumber, int cardExpiryMonth, int cardExpiryYear, string cardVerificationCode = null, string cardHolderName = null)
            {
                CardNumber = cardNumber;
                CardExpiryMonth = cardExpiryMonth;
                CardExpiryYear = cardExpiryYear;
                CardVerificationCode = cardVerificationCode;
                CardHolderName = cardHolderName;
            }

            public string CardNumber { get; }
            public int CardExpiryMonth { get; }
            public int CardExpiryYear { get; }
            public string CardVerificationCode { get; }
            public string CardHolderName { get; }
        }
    }
}
