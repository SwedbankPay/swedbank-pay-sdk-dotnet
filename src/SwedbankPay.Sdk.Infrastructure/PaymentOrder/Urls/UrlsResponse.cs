using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;

internal record UrlsResponse : Identifiable, IUrlsResponse
{
    internal UrlsResponse(UrlsResponseDto urls) : base(urls.Id)
    {
        CallbackUrl = urls.CallbackUrl != null ? new Uri(urls.CallbackUrl, UriKind.RelativeOrAbsolute) : null;
        CancelUrl = urls.CancelUrl != null ? new Uri(urls.CancelUrl, UriKind.RelativeOrAbsolute) : null;
        CompleteUrl = urls.CompleteUrl != null ? new Uri(urls.CompleteUrl, UriKind.RelativeOrAbsolute) : null;
        HostUrls = urls.HostUrls?.Select(url => new Uri(url, UriKind.RelativeOrAbsolute)).ToList();
        LogoUrl = urls.LogoUrl != null ? new Uri(urls.LogoUrl, UriKind.RelativeOrAbsolute) : null;
        PaymentUrl = urls.PaymentUrl != null ? new Uri(urls.PaymentUrl, UriKind.RelativeOrAbsolute) : null;
        TermsOfServiceUrl = urls.TermsOfServiceUrl != null ? new Uri(urls.TermsOfServiceUrl, UriKind.RelativeOrAbsolute) : null;
    }

    public Uri? CallbackUrl { get; }
    public Uri? CancelUrl { get; }
    public Uri? CompleteUrl { get; }
    public IList<Uri>? HostUrls { get; }
    public Uri? LogoUrl { get; }
    public Uri? PaymentUrl { get; }
    public Uri? TermsOfServiceUrl { get; }
}