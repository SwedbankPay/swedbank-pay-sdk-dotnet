namespace SwedbankPay.Sdk;

internal class OperationResponseDto
{
    public OperationResponseDto(string method, string href, string rel, string contentType)
    {
        Method = method;
        Href = href;
        Rel = rel;
        ContentType = contentType;
    }

    public string Method { get; }
    public string Href { get; }
    public string Rel { get; }
    public string ContentType { get; }
}