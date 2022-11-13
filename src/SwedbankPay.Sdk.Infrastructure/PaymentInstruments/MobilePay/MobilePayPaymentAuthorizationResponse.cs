﻿using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

internal class MobilePayPaymentAuthorizationResponse : IMobilePayPaymentAuthorizationResponse
{
    public MobilePayPaymentAuthorizationResponse(Uri payment, MobilePayPaymentAuthorization authorization)
    {
        Payment = payment;
        Authorization = authorization;
    }

    public Uri Payment { get; }

    public IMobilePayPaymentAuthorization Authorization { get; }
}