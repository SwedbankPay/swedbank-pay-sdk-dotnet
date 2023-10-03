namespace SwedbankPay.Sdk;

public record Urls
{
    public Urls(IList<Uri>? hostUrls, Uri completeUrl, Uri cancelUrl, Uri callbackUrl)
    {
        HostUrls = hostUrls;
        CompleteUrl = completeUrl;
        CancelUrl = cancelUrl;
        CallbackUrl = callbackUrl;
    }

    internal Urls(UrlsDto dto)
    {
        HostUrls = dto.HostUrls?.Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => new Uri(x, UriKind.RelativeOrAbsolute)).ToList();
        PaymentUrl = !string.IsNullOrWhiteSpace(dto.PaymentUrl)
            ? new Uri(dto.PaymentUrl, UriKind.RelativeOrAbsolute)
            : null;
        LogoUrl = !string.IsNullOrWhiteSpace(dto.LogoUrl)
            ? new Uri(dto.LogoUrl, UriKind.RelativeOrAbsolute)
            : null;
        CompleteUrl = !string.IsNullOrWhiteSpace(dto.CompleteUrl)
            ? new Uri(dto.CompleteUrl, UriKind.RelativeOrAbsolute)
            : null;
        CancelUrl = !string.IsNullOrWhiteSpace(dto.CancelUrl)
            ? new Uri(dto.CancelUrl, UriKind.RelativeOrAbsolute)
            : null;
        CallbackUrl = !string.IsNullOrWhiteSpace(dto.CallbackUrl)
            ? new Uri(dto.CallbackUrl, UriKind.RelativeOrAbsolute)
            : null;
    }
    
    public IList<Uri>? HostUrls { get; }
    public Uri? PaymentUrl { get; set; }
    public Uri? LogoUrl { get; set; }
    public Uri? CompleteUrl { get; }
    public Uri? CancelUrl { get; }
    public Uri? CallbackUrl { get; }
}