using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationsResponse
    {
        IPaymentAuthorizationListResponse AuthorizationList { get; }
        Uri Payment { get; }
    }
}