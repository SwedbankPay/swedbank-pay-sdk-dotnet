namespace SwedbankPay.Sdk
{
    using RestSharp;

    public class HttpOperation
    {
        /// <summary>
        /// The target URI of the operation. 
        /// </summary>
        public string Href { get; protected set; }
        /// <summary>
        /// The relational name of the operation, used as a programmatic identifier to find the correct operation given the current state of the application.
        /// </summary>
        public string Rel { get; protected set; }
        /// <summary>
        /// The HTTP method to use when performing the operation.
        /// </summary>
        public Method Method { get; protected set; }
        /// <summary>
        /// The HTTP content type of the target URI. Indicates what sort of resource is to be found at the URI, how it is expected to be used and behave.
        /// </summary>
        public string ContentType { get; protected set; }
    }
    public enum HttpMethod
    {
        PATCH,
        POST,
        GET
    }
}