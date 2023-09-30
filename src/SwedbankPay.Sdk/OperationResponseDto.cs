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

    public string Method { get; set; }
    public string Href { get; set; }
    public string Rel { get; set; }
    public string ContentType { get; set; }
}