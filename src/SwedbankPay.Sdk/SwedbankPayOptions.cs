using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayOptions
    {
        public Uri ApiBaseUrl { get; set; }
        public Uri CallBackUrl { get; set; }
        public Uri CancelPageUrl { get; set; }
        public Uri CompletePageUrl { get; set; }
        public List<Uri> HostUrls { get; set; }
        public Uri LogoUrl { get; set; }
        public string MerchantId { get; set; }
        public Uri PaymentUrl { get; set; }
        public Uri TermsOfServiceUrl { get; set; }
        public string Token { get; set; }


        public bool IsEmpty()
        {
            return ApiBaseUrl == null || string.IsNullOrEmpty(Token) || string.IsNullOrEmpty(MerchantId);
        }
    }
}