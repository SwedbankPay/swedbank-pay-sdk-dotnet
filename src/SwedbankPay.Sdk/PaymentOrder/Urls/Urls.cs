namespace SwedbankPay.Sdk.PaymentOrder.Urls;

public record Urls : IUrls
{
    public Urls(IList<Uri>? hostUrls, Uri completeUrl, Uri callbackUrl)
    {
        HostUrls = hostUrls;
        CompleteUrl = completeUrl;
        CallbackUrl = callbackUrl;
    }

    public IList<Uri>? HostUrls { get; }
    public Uri? PaymentUrl { get; set; }
    public Uri? CompleteUrl { get; }
    public Uri? CallbackUrl { get; }
    public Uri? CancelUrl { get; set; }
    
    public Uri? TermsOfServiceUrl { get; set; }
    public Uri? LogoUrl { get; set; }
}