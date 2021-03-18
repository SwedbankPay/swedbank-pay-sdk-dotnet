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
                                     IProblem problemResponse = null,
                                     string message = null,
                                     Exception innerException = null)
            : base(message, innerException)
        {
            HttpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            ProblemResponse = problemResponse;
        }

        /// <summary>
        /// The <seealso cref="HttpResponseMessage"/> that was part of the exception.
        /// </summary>
        public HttpResponseMessage HttpResponse { get; set; }

        /// <summary>
        /// The <seealso cref="IProblem"/> in the <seealso cref="HttpResponseException"/>.
        /// </summary>
        public IProblem ProblemResponse { get; set; }

        /// <summary>
        /// Instantiates a new empty <seealso cref="HttpResponseException"/>.
        /// </summary>
        public HttpResponseException()
        {
        }

        /// <summary>
        /// Instantiates a new <seealso cref="HttpResponseException"/> with only a <paramref name="message"/>.
        /// </summary>
        /// <param name="message"></param>
        public HttpResponseException(string message) : base(message)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="HttpResponseException"/> with the provided parameters.
        /// </summary>
        /// <param name="message">The message of the <seealso cref="Exception"/>.</param>
        /// <param name="innerException">The inner <seealso cref="Exception"/>.</param>
        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}