namespace Sample.AspNetCore.SystemTests.Test.Helpers
{
    public class PayexCardInfo : PayexInfo
    {
        public PayexCardInfo(string creditCardNumber, string expiryDate, string cvc, bool isVerification)
        {
            CreditCardNumber = creditCardNumber;
            ExpiryDate = expiryDate;
            Cvc = cvc;
            IsVerification = isVerification;
        }


        public string CreditCardNumber { get; }
        public string Cvc { get; }
        public bool IsVerification { get; }
        public string ExpiryDate { get; }
    }
}