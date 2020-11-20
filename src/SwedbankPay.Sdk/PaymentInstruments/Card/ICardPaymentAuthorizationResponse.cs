using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationResponse
    {
        ICardPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}