using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentAuthorizationResponse
    {
        MobilePayPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}