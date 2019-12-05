namespace Sample.AspNetCore.Models
{
    using SwedbankPay.Sdk;

    public class SwedbankPayCheckoutSource
    {
        public string JavascriptSource { get; set; }
        public bool UseAnonymousCheckout { get; set; }
        public string Culture { get; set; }
        public string AbortOperationLink { get; set; }
        public HttpOperation UpdateOperation { get; set; }


    }
}