namespace SwedbankPay.Sdk;

public record Urls(IList<Uri> HostUrls, Uri CompleteUrl, Uri CancelUrl, Uri CallbackUrl)
{
    public Uri? PaymentUrl { get; set; }
    public Uri? LogoUrl { get; set; }
}