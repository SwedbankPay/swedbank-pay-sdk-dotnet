using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationListResponse : IdLink, IPaymentAuthorizationListResponse
    {
        public List<IPaymentAuthorization> AuthorizationList { get; }
    }
}