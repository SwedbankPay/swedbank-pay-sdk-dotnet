using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationResponse
    {
        public VippsPaymentAuthorizationResponse(Uri payment, VippsPaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public VippsPaymentAuthorization Authorization { get; }

        public Uri Payment { get; }
    }
}