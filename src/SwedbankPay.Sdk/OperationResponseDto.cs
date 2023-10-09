namespace SwedbankPay.Sdk;

internal record OperationResponseDto(string Method, string Href, string Rel, string ContentType)
{
    public string Method { get; } = Method;
    public string Href { get; } = Href;
    public string Rel { get; } = Rel;
    public string ContentType { get; } = ContentType;
}