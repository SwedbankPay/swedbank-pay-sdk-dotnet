using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationListResponseDto
    {
        public Uri Id { get; set; }
        public List<VippsPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IVippsPaymentAuthorizationListResponse Map()
        {
            var list = new List<IVippsPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(item.Map());
            }
            return new VippsPaymentAuthorizationListResponse(Id, list);
        }
    }
}