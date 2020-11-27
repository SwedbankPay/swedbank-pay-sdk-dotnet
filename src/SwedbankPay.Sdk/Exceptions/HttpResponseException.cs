using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    /// <summary>
    /// Contains detailed information about an <seealso cref="Exception"/> made during a HTTP request.
    /// </summary>
    [Serializable]
    public class HttpResponseException : Exception
    {
        /// <summary>
        /// Instantiates a new <seealso cref="HttpResponseException"/> with the parameters passed in.
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <param name="problemResponse"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public HttpResponseException(HttpResponseMessage httpResponse,
                                     IProblemResponse problemResponse = null,
                                     string message = null,
                                     Exception innerException = null)
            : base(message, innerException)
        {
            HttpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            ProblemResponse = problemResponse;
        }

        public HttpResponseMessage HttpResponse { get; set; }

        public IProblemResponse ProblemResponse { get; set; }

        public HttpResponseException()
        {
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}