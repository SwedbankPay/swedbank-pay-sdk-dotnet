namespace SwedbankPay.Sdk.Payments.Invoice
{
    public class AuthorizationRequest
    {
        public AuthorizationRequest(string transactionActivity,
                                    int socialSecurityNumber,
                                    int customerNumber,
                                    string ip,
                                    string addressee,
                                    string streetAddress
                                    string email = null,
                                    string msisdn = null)
        {
            Transaction = new AuthorizationTransaction(transactionActivity, socialSecurityNumber, customerNumber, email, msisdn, ip, addressee, streetAddress);
        }


        public AuthorizationTransaction Transaction { get; }

        public class AuthorizationTransaction
        {
            protected internal AuthorizationTransaction(string transactionActivity,
                                                        int socialSecurityNumber,
                                                        int customerNumber,
                                                        string ip,
                                                        string addressee,
                                                        string streetAddress,
                                                        string email = null,
                                                        string msisdn = null)
            {
                TransactionActivity = transactionActivity;
                SocialSecurityNumber = socialSecurityNumber;
                CustomerNumber = customerNumber;
                Email = email;
                Msisdn = msisdn;
                Ip = ip;
                Addressee = addressee;
                streetAddress = 
            }


            public int SocialSecurityNumber { get; }
            public int CustomerNumber { get; }
            public string Msisdn { get; }
            public string Ip { get; }
            public string TransactionActivity { get; }
            public string Email { get; }
            public string Addressee { get; }
        }
    }
}