namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class AuthorizationRequest
    {
        public AuthorizationRequest(string transactionActivity,
                                    int socialSecurityNumber,
                                    string ip,
                                    string addressee,
                                    string zipCode,
                                    string city,
                                    string countryCode,
                                    int? customerNumber = null,
                                    EmailAddress email = null,
                                    string msisdn = null,
                                    string coAddress = null,
                                    string streetAddress = null)
        {
            Transaction = new AuthorizationTransaction(transactionActivity, socialSecurityNumber,  ip, addressee, zipCode, city, countryCode, customerNumber, email, msisdn, coAddress, streetAddress);
        }


        public AuthorizationTransaction Transaction { get; }

        public class AuthorizationTransaction
        {
            protected internal AuthorizationTransaction(string transactionActivity,
                                                        int socialSecurityNumber,
                                                        string ip,
                                                        string addressee,
                                                        string zipCode,
                                                        string city,
                                                        string countryCode,
                                                        int? customerNumber = null,
                                                        EmailAddress email = null,
                                                        string msisdn = null,
                                                        string coAddress = null,
                                                        string streetAddress = null)
            {
                TransactionActivity = transactionActivity;
                SocialSecurityNumber = socialSecurityNumber;
                CustomerNumber = customerNumber;
                Email = email;
                Msisdn = msisdn;
                Ip = ip;
                Addressee = addressee;
                StreetAddress = streetAddress;
                ZipCode = zipCode;
                City = city;
                CountryCode = countryCode;
                CoAddress = coAddress;

            }

            /// <summary>
            /// The social security number (national identity number) of the consumer. Format Sweden: YYMMDD-NNNN. 
            /// Format Norway: DDMMYYNNNNN. Format Finland: DDMMYYNNNNN
            /// </summary>
            public int SocialSecurityNumber { get; }
            /// <summary>
            /// The customer number in the merchant system.
            /// </summary>
            public int? CustomerNumber { get; }
            /// <summary>
            /// The mobile phone number of the consumer. Format Sweden: +46707777777. Format Norway: +4799999999. 
            /// Format Finland: +358501234567
            /// </summary>
            public string Msisdn { get; }
            /// <summary>
            /// The IP address of the consumer.
            /// </summary>
            public string Ip { get; }
            /// <summary>
            /// FinancingConsumer
            /// </summary>
            public string TransactionActivity { get; }
            /// <summary>
            /// The e-mail address of the consumer.
            /// </summary>
            public EmailAddress Email { get; }
            /// <summary>
            /// The full (first and last) name of the consumer.
            /// </summary>
            public string Addressee { get; }
            /// <summary>
            /// The street address of the consumer.
            /// </summary>
            public string StreetAddress { get; }
            /// <summary>
            /// The postal code (ZIP code) of the consumer.
            /// </summary>
            public string ZipCode { get; }
            /// <summary>
            /// The city to the consumer.
            /// </summary>
            public string City { get; }
            /// <summary>
            /// SE, NO, or FI. The country code of the consumer.
            /// </summary>
            public string CountryCode { get; }
            /// <summary>
            /// The CO-address (if used)
            /// </summary>
            public string CoAddress { get; }
            
        }
    }
}