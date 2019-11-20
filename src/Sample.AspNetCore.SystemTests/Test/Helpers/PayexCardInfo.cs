namespace Sample.AspNetCore.SystemTests.Test.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PayexCardInfo : PayexInfo
    {
        public string CreditCardNumber { get; private set; }
        public string ExpiryDate { get; private set; }
        public string Cvc { get; private set; }

        public PayexCardInfo(string creditCardNumber, string expiryDate, string cvc)
        {
            CreditCardNumber = creditCardNumber;
            ExpiryDate = expiryDate;
            Cvc = cvc;
        }
    }
}
