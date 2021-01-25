using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class AuthorizationTransactionDto
    {
        public string Id { get; set; }
        public List<PaymentAuthorizationDto> AuthorizationList { get; set; } = new List<PaymentAuthorizationDto>();
        internal ICardPaymentAuthorizationListResponse Map()
        {
            var list = new List<IPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(new PaymentAuthorization(item));
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new CardPaymentAuthorizationListResponse(uri, list);
        }
    }
}