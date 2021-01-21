using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationListDto
    {
        public Uri Id { get; set; }
        public List<VippsPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IVippsPaymentAuthorizationList Map()
        {
            var list = new List<IVippsPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(item.Map());
            }
            return new VippsPaymentAuthorizationList(Id, list);
        }
    }
}