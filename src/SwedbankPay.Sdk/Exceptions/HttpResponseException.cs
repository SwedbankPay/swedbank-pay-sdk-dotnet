using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage httpResponse,
                                     ProblemResponse problemResponse = null,
                                     string message = null,
                                     Exception innerException = null)
            : base(message, innerException)
        {
            HttpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            ProblemResponse = problemResponse;
        }


        public HttpResponseMessage HttpResponse { get; }

        public ProblemResponse ProblemResponse { get; }

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