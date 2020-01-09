namespace SwedbankPay.Sdk.Transactions
{
    public class AuthorizationTransactionRequest
    {
        public AuthorizationTransactionRequest(string cardNumber, int cardExpiryMonth, int cardExpiryYear, string cardVerificationCode = null, string cardHolderName = null)
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