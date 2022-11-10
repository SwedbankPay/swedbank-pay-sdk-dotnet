using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

internal class VippsPaymentAuthorizationResponseDto
{
    public VippsPaymentAuthorizationDto Authorization { get; set; }

    public Uri Payment { get; set; }
}