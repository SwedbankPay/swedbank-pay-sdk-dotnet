using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentAuthorizationListResponse : IdLink, IPaymentAuthorizationListResponse
    {
        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}