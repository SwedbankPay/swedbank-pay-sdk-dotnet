using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentAuthorizationResponse
    {
        IVippsPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}