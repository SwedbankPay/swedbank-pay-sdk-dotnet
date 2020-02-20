using System;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentAuthorizationResponse
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