using System.Net.Http;

namespace SwedbankPay.Sdk
{
    public class HttpOperation
    {
        public HttpOperation(string href, LinkRelation rel, string method, string contentType)
        {
            Href = href;
            Rel = rel;
            Method = new HttpMethod(method);
            ContentType = contentType;
            var request = new HttpRequestMessage(new HttpMethod(method), href);
            request.Headers.Add("Accept", contentType);
            Request = request;
        }


        /// <summary>
        /// The target URI of the operation. 
        /// </summary>

        public string Href { get; }

        /// <summary>
        /// The relational name of the operation, used as a programmatic identifier to find the correct operation given the current state of the application.
        /// </summary>
        public LinkRelation Rel { get; }

        /// <summary>
        /// The HTTP method to use when performing the operation.
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// The HTTP content type of the target URI. Indicates what sort of resource is to be found at the URI, how it is expected to be used and behave.
        /// </summary>

        public string ContentType { get; }

        public HttpRequestMessage Request { get; }
    }
}