using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationResponse
    {
        public VippsPaymentAuthorizationResponse(Uri payment, IVippsPaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public IVippsPaymentAuthorization Authorization { get; }

        public Uri Payment { get; }
    }
}