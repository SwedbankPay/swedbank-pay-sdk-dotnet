namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class AuthorizationRequest
    {
        public AuthorizationRequest(string activity,
                                    string mpoProcessPaymentSessionToken,
                                    string mpoProcessPaymentCardType,
                                    string mpoProcessPaymentValidUntil,
                                    string errorCode = null,
                                    string errorDescription = null)
        {
            Transaction = new AuthorizationTransaction(activity, mpoProcessPaymentSessionToken, mpoProcessPaymentCardType, mpoProcessPaymentValidUntil, errorCode, errorDescription);
        }

        public AuthorizationTransaction Transaction { get; }

        public class AuthorizationTransaction
        {
            protected internal AuthorizationTransaction(string activity,
                                                        string mpoProcessPaymentSessionToken,
                                                        string mpoProcessPaymentCardType,
                                                        string mpoProcessPaymentValidUntil,
                                                        string errorCode = null,
                                                        string errorDescription = null)
            {
                Activity = activity;
                MpoProcessPaymentSessionToken = mpoProcessPaymentSessionToken;
                MpoProcessPaymentCardType = mpoProcessPaymentCardType;
                MpoProcessPaymentValidUntil = mpoProcessPaymentValidUntil;
                ErrorCode = errorCode;
                ErrorDescription = errorDescription;
            }


            public string Activity { get; }
            public string MpoProcessPaymentSessionToken { get; }
            public string MpoProcessPaymentCardType { get; }

            public string MpoProcessPaymentValidUntil { get; }
            public string ErrorCode { get; }
            public string ErrorDescription { get; }
        }
    }
}