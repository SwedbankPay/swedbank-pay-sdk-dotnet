using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentAuthorizationResponse
    {
        IMobilePayPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}