using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationListResponseDto
    {
        public string Id { get; set; }
        public List<VippsPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IVippsPaymentAuthorizationListResponse Map()
        {
            var list = new List<IVippsPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(item.Map());
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new VippsPaymentAuthorizationListResponse(uri, list);
        }
    }
}