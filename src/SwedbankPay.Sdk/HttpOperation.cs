namespace SwedbankPay.Sdk
{
    public class HttpOperation
    {
        public string Href { get; protected set; }
        public string Rel { get; protected set; }
        public HttpMethod Method { get; protected set; }
        public string ContentType { get; protected set; }
    }
    public enum HttpMethod
    {
        PATCH,
        POST,
        GET
    }
}