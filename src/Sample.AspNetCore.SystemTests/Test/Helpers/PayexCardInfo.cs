namespace Sample.AspNetCore.SystemTests.Test.Helpers
{
    public class PayexCardInfo : PayexInfo
    {
        public PayexCardInfo(string creditCardNumber, string expiryDate, string cvc)
        {
            CreditCardNumber = creditCardNumber;
            ExpiryDate = expiryDate;
            Cvc = cvc;
        }


        public string CreditCardNumber { get; }
        public string Cvc { get; }
        public string ExpiryDate { get; }
    }
}