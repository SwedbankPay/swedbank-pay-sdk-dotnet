using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationsResponse
    {
        ICardPaymentAuthorizationListResponse AuthorizationList { get; }
        Uri Payment { get; }
    }
}