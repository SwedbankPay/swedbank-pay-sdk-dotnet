namespace SwedbankPay.Sdk
{
    public class HttpOperation
    {
        public HttpOperation(string href, string rel, string method, string contentType)
        {
            Href = href;
            Rel = rel;
            Method = method;
            ContentType = contentType;
        }


        /// <summary>
        /// The target URI of the operation. 
        /// </summary>

        public string Href { get; }

        /// <summary>
        /// The relational name of the operation, used as a programmatic identifier to find the correct operation given the current state of the application.
        /// </summary>
        public string Rel { get; }

        /// <summary>
        /// The HTTP method to use when performing the operation.
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// The HTTP content type of the target URI. Indicates what sort of resource is to be found at the URI, how it is expected to be used and behave.
        /// </summary>

        public string ContentType { get; }
    }
}