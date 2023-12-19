namespace SwedbankPay.Sdk.PaymentOrder.Urls;

public record Urls : IUrls
{
    public Urls(IList<Uri>? hostUrls, Uri completeUrl, Uri cancelUrl, Uri callbackUrl)
    {
        HostUrls = hostUrls;
        CompleteUrl = completeUrl;
        CancelUrl = cancelUrl;
        CallbackUrl = callbackUrl;
    }
    
    public IList<Uri>? HostUrls { get; }
    public Uri? PaymentUrl { get; set; }
    public Uri? TermsOfServiceUrl { get; set; }
    public Uri? LogoUrl { get; set; }
    public Uri? CompleteUrl { get; }
    public Uri? CancelUrl { get; }
    public Uri? CallbackUrl { get; }
}