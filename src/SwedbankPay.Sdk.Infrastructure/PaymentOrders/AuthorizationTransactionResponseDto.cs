using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class AuthorizationTransactionResponseDto
    {
        public string Id { get; set; }
        public List<PaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IPaymentAuthorizationListResponse Map()
        {
            var list = new List<IPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(item.Map());
            }
            return new PaymentAuthorizationListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}