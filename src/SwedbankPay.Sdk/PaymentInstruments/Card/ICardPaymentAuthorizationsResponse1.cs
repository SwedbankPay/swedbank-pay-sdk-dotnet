using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationsResponse1
    {
        ICardPaymentAuthorizationListResponse AuthorizationList { get; }
        Uri Payment { get; }
    }
}