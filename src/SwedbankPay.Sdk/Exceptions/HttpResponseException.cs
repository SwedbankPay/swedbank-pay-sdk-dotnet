using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpResponseException(HttpResponseMessage httpResponse, ProblemsContainer problemsContainer = null, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            HttpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            ProblemsContainer = problemsContainer;
        }

        public HttpResponseMessage HttpResponse { get; }

        public ProblemsContainer ProblemsContainer { get; }
    }
}
