namespace SwedbankPay.Sdk;

public record Urls(IList<Uri> HostUrls, Uri CompleteUrl, Uri CancelUrl, Uri CallbackUrl)
{
    public Uri? PaymentUrl { get; set; }
    public Uri? LogoUrl { get; set; }
    public IList<Uri> HostUrls { get; } = HostUrls;
    public Uri CompleteUrl { get; } = CompleteUrl;
    public Uri CancelUrl { get; } = CancelUrl;
    public Uri CallbackUrl { get; } = CallbackUrl;
}