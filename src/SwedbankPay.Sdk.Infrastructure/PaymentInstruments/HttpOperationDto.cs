using SwedbankPay.Sdk.Common;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class HttpOperationDto
    {
        public string ContentType { get; }

        public Uri Href { get; }
        public string Method { get; }
        public LinkRelation Rel { get; }
        public HttpRequestMessage Request { get; }
    }
}