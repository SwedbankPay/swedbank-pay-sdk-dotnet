using SwedbankPay.Sdk.Common;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationListResponse
    {
        List<IPaymentAuthorization> AuthorizationList { get; }
    }
}