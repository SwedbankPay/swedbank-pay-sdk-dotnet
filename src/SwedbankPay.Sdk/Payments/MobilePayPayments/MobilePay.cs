using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class MobilePayRequestObject
    {
        public MobilePayRequestObject(Uri shoplogoUrl)
        {
            ShoplogoUrl = shoplogoUrl;
        }

        /// <summary>
        ///    URI to logo that will be visible at MobilePay payment menu
        /// </summary>
        public Uri ShoplogoUrl { get; }


    }
}