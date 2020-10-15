using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
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