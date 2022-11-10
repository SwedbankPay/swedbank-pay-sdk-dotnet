using System;

namespace SwedbankPay.Sdk;

internal class HttpOperationDto
{
    public string ContentType { get; set; }
    public Uri Href { get; set; }
    public string Method { get; set; }
    public string Rel { get; set; }
}