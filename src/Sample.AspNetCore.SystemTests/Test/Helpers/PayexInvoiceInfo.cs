namespace Sample.AspNetCore.SystemTests.Test.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PayexInvoiceInfo : PayexInfo
    {
        public string PersonalNumber { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ZipCode { get; private set; }

        public PayexInvoiceInfo(string personalNumber, string email, string phoneNumber, string zipCode)
        {
            PersonalNumber = personalNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            ZipCode = zipCode;
        }
    }
}
