﻿using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentAuthorizationResponse : ICardPaymentAuthorizationResponse
{
    public CardPaymentAuthorizationResponse(Uri payment, ICardPaymentAuthorization authorization)
    {
        Payment = payment;
        Authorization = authorization;
    }


    public ICardPaymentAuthorization Authorization { get; }

    public Uri Payment { get; }
}