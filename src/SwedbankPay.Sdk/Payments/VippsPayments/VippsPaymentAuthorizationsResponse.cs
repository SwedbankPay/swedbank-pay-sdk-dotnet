using System;

namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class VippsPaymentAuthorizationsResponse
    {
        public VippsPaymentAuthorizationsResponse(Uri payment, VippsPaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public VippsPaymentAuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}