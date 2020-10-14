using System;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentAuthorizationResponse : IMobilePayPaymentAuthorizationResponse
    {
        public MobilePayPaymentAuthorizationResponse(Uri payment, MobilePayPaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public MobilePayPaymentAuthorization Authorization { get; }

        public Uri Payment { get; }
    }
}