using System;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentAuthorizationsResponse
    {
        public MobilePayPaymentAuthorizationsResponse(Uri payment, MobilePayPaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public MobilePayPaymentAuthorizationListResponse AuthorizationList { get; }
        public Uri Payment { get; }
    }
}
