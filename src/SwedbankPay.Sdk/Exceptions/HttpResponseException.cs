using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    [Serializable]
    public class HttpResponseException : Exception
    {
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