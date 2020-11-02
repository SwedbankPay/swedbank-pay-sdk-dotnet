using SwedbankPay.Sdk.PaymentInstruments.Card;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class AuthorizationTransactionDto : List<PaymentAuthorizationDto>
    {
        internal ICardPaymentAuthorizationListResponse Map()
        {
            var list = new List<IPaymentAuthorization>();
            foreach (var item in this)
            {
                list.Add(new PaymentAuthorization(item));
            }
            return new CardPaymentAuthorizationListResponse(list);
        }
    }
}