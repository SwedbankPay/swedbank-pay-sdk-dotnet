using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationListDto
    {
        public Uri Id { get; set; }
        public List<MobilePayPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IMobilePayPaymentAuthorizationList Map()
        {
            var list = new List<IMobilePayPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(new MobilePayPaymentAuthorization(Id, item));
            }
            return new MobilePayPaymentAuthorizationList(Id, list);
        }
    }
}