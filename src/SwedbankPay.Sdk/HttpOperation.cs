using RestSharp;

namespace SwedbankPay.Sdk
{
    public class HttpOperation
    {
        public string Href { get; protected set; }
        public string Rel { get; protected set; }
        public Method Method { get; protected set; }
        public string ContentType { get; protected set; }
    }
    public enum HttpMethod
    {
        PATCH,
        POST,
        GET
    }
}