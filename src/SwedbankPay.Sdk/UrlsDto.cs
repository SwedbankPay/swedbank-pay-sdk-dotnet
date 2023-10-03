using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk;

internal record UrlsDto
{
    [JsonConstructor]
    public UrlsDto()
    {
    }

    public UrlsDto(Urls urls)
    {
        HostUrls = urls.HostUrls?.Select(x => x.ToString());
        PaymentUrl = urls.PaymentUrl?.ToString();
        CompleteUrl = urls.CompleteUrl.ToString();
        CancelUrl = urls.CancelUrl.ToString();
        CallbackUrl = urls.CallbackUrl.ToString();
        LogoUrl = urls.LogoUrl?.ToString();
    }

    public IEnumerable<string>? HostUrls { get; set; }
    public string? PaymentUrl { get; set; }
    public string? CompleteUrl { get; set; }
    public string? CancelUrl { get; set; }
    public string? CallbackUrl { get; set; }
    public string? LogoUrl { get; set; }

    public Urls Map()
    {
        return new Urls(this);
    }
}