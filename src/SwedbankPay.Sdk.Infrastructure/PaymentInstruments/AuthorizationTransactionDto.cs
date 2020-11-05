using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class AuthorizationTransactionDto
    {
        public Uri Id { get; set; }
        public List<PaymentAuthorizationDto> Authorizations { get; set; } = new List<PaymentAuthorizationDto>();
        internal ICardPaymentAuthorizationListResponse Map()
        {
            var list = new List<IPaymentAuthorization>();
            foreach (var item in Authorizations)
            {
                list.Add(new PaymentAuthorization(item));
            }
            return new CardPaymentAuthorizationListResponse(list);
        }
    }
}