using System;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobilePayPaymentAuthorizationResponse
    {
        MobilePayPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}