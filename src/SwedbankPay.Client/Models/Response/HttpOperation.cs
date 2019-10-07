namespace SwedbankPay.Client.Models.Response
{
    public class HttpOperation
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public HttpMethod Method { get; set; }
        public string ContentType { get; set; }
    }
    public enum HttpMethod
    {
        PATCH,
        POST,
        GET
    }
}