using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorizationListResponse
    {
        List<ICardPaymentAuthorization> AuthorizationList { get; }
    }
}