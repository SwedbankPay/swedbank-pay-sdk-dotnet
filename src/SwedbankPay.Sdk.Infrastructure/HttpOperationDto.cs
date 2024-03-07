namespace SwedbankPay.Sdk.Infrastructure;

internal record HttpOperationDto
{
    public string ContentType { get; init; } = null!;
    public string Href { get; init; } = null!;
    public string Method { get; init; } = null!;
    public string Rel { get; init; } = null!;
}