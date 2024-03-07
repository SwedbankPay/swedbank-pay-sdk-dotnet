using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;

internal record UrlsResponseDto : IdentifiableDto
{
    public string? CallbackUrl { get; }
    public string? CancelUrl { get; }
    public string? CompleteUrl { get; }
    public IList<string>? HostUrls { get; }
    public string? LogoUrl { get; }
    public string? PaymentUrl { get; }
    public string? TermsOfServiceUrl { get; }

    public IUrlsResponse Map()
    {
        return new UrlsResponse(this);
    }
}