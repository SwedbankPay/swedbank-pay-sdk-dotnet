using System;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models
{
    public class SwedbankPayCheckoutSource
    {
        public Uri AbortOperationLink { get; set; }
        public string Culture { get; set; }
        public Uri JavascriptSource { get; set; }
        public HttpOperation UpdateOperation { get; set; }
        public bool UseAnonymousCheckout { get; set; }
    }
}