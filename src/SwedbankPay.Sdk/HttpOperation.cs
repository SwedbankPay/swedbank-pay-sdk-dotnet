using System;
using System.Net.Http;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Holds information about a API relevant Operation.
    /// </summary>
    public class HttpOperation
    {
        /// <summary>
        /// Instansiates a new <seealso cref="HttpOperation"/> with the provided parameters.
        /// </summary>
        /// <param name="href">The <seealso cref="Uri"/> for the operation.</param>
        /// <param name="rel">The name of the operation.</param>
        /// <param name="method">The <seealso cref="HttpMethod"/> as a string for the operation.</param>
        /// <param name="contentType">The content type of the operation.</param>
        public HttpOperation(Uri href, LinkRelation rel, string method, string contentType)
        {
            Href = href;
            Rel = rel;
            Method = new HttpMethod(method);
            ContentType = contentType;
            if (href.Scheme == Uri.UriSchemeHttp || href.Scheme == Uri.UriSchemeHttps)
            {
                var request = new HttpRequestMessage(new HttpMethod(method), href);
                request.Headers.Add("Accept", contentType);
                Request = request;
            }
        }


        /// <summary>
        ///     The HTTP content type of the target URI. Indicates what sort of resource is to be found at the URI, how it is
        ///     expected to be used and behave.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        ///     The target URI of the operation.
        /// </summary>
        public Uri Href { get; }

        /// <summary>
        ///     The HTTP method to use when performing the operation.
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        ///     The relational name of the operation, used as a programmatic identifier to find the correct operation given the
        ///     current state of the application.
        /// </summary>
        public LinkRelation Rel { get; }

        /// <summary>
        /// Contains a preset header to accept <see cref="ContentType"/>
        /// </summary>
        public HttpRequestMessage Request { get; }
    }
}