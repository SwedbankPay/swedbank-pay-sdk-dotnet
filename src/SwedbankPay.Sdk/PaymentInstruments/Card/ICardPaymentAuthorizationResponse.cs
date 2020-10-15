using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationResponse
    {
        IPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}