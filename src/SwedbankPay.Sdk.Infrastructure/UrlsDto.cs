using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class UrlsDto
    {
        public Uri CallbackUrl { get; set; }

        public Uri CancelUrl { get; set; }

        public Uri CompleteUrl { get; set; }

        public ICollection<Uri> HostUrls { get; set; }

        public Uri LogoUrl { get; set; }

        public Uri PaymentUrl { get; set; }

        public Uri TermsOfServiceUrl { get; set; }

        internal IUrls Map()
        {
            throw new NotImplementedException();
        }
    }
}