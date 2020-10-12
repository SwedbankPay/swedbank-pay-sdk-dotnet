using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationsResponse
    {
        ICardPaymentAuthorizationListResponse AuthorizationList { get; }
        Uri Payment { get; }
    }
}