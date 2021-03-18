using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentAuthorizationListResponseDto
    {
        public string Id { get; set; }
        public List<MobilePayPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IMobilePayPaymentAuthorizationListResponse Map()
        {
            var list = new List<IMobilePayPaymentAuthorization>();
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            foreach (var item in AuthorizationList)
            {
                list.Add(new MobilePayPaymentAuthorization(uri, item));
            }
            return new MobilePayPaymentAuthorizationListResponse(uri, list);
        }
    }
}