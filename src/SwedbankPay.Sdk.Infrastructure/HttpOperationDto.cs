using SwedbankPay.Sdk.Common;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk
{
    public class HttpOperationDto
    {
        public string ContentType { get; set; }

        public Uri Href { get; set; }
        public string Method { get; set; }
        public string Rel { get; set; }
        public HttpRequestMessage Request { get; set; }
    }
}