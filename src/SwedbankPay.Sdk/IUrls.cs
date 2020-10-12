using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public interface IUrls
    {
        Uri CallbackUrl { get; }
        Uri CancelUrl { get; }
        Uri CompleteUrl { get; }
        ICollection<Uri> HostUrls { get; }
        Uri LogoUrl { get; }
        Uri PaymentUrl { get; }
        Uri TermsOfServiceUrl { get; }
    }
}