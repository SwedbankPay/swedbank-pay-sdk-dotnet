using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentAuthorizationListResponseDto
    {
        public Uri Id { get; set; }
        public List<MobilePayPaymentAuthorizationDto> AuthorizationList { get; set; }

        internal IMobilePayPaymentAuthorizationListResponse Map()
        {
            var list = new List<IMobilePayPaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(new MobilePayPaymentAuthorization(Id, item));
            }
            return new MobilePayPaymentAuthorizationListResponse(Id, list);
        }
    }
}