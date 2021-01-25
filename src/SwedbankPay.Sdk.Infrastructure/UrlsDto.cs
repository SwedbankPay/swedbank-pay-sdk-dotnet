using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class UrlsDto
    {
        public UrlsDto() { }

        public UrlsDto(IUrls urls)
        {
            CallbackUrl = urls.CallbackUrl;
            CancelUrl = urls.CancelUrl;
            CompleteUrl = urls.CompleteUrl;
            LogoUrl = urls.LogoUrl;
            PaymentUrl = urls.PaymentUrl;
            TermsOfServiceUrl = urls.TermsOfServiceUrl;
            HostUrls = urls.HostUrls;
        }

        public string Id { get; set; }

        public Uri CallbackUrl { get; set; }

        public Uri CancelUrl { get; set; }

        public Uri CompleteUrl { get; set; }

        public IList<Uri> HostUrls { get; set; }

        public Uri LogoUrl { get; set; }

        public Uri PaymentUrl { get; set; }

        public Uri TermsOfServiceUrl { get; set; }

        internal IUrls Map()
        {
            if (HostUrls == null)
            {
                var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
                return new Identifiable(uri) as IUrls;
            }

            return new UrlsResponse(this);
        }
    }
}