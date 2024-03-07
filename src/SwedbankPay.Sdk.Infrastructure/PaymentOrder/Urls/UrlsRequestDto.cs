using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;

internal record UrlsRequestDto
{
    public UrlsRequestDto(IUrls urls)
    {
        HostUrls = urls.HostUrls?.Select(x => x.ToString());
        PaymentUrl = urls.PaymentUrl?.ToString();
        CompleteUrl = urls.CompleteUrl?.ToString();
        CancelUrl = urls.CancelUrl?.ToString();
        CallbackUrl = urls.CallbackUrl?.ToString();
        LogoUrl = urls.LogoUrl?.ToString();
    }
    
    public string? Id { get; set; }
    public IEnumerable<string>? HostUrls { get; set; }
    public string? PaymentUrl { get; set; }
    public string? CompleteUrl { get; set; }
    public string? CancelUrl { get; set; }
    public string? CallbackUrl { get; set; }
    public string? LogoUrl { get; set; }
}