using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationResponse
    {
        ICardPaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}