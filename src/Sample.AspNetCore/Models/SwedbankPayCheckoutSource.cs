using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models
{
    public class SwedbankPayCheckoutSource
    {
        public string AbortOperationLink { get; set; }
        public string Culture { get; set; }
        public string JavascriptSource { get; set; }
        public HttpOperation UpdateOperation { get; set; }
        public bool UseAnonymousCheckout { get; set; }
    }
}