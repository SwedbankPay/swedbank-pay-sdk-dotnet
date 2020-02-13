using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class MobilePayPaymentRequestObject
    {
        public MobilePayPaymentRequestObject(Uri shoplogoUrl)
        {
            ShoplogoUrl = shoplogoUrl;
        }

        /// <summary>
        ///    URI to logo that will be visible at MobilePay payment menu
        /// </summary>
        public Uri ShoplogoUrl { get; }


    }
}