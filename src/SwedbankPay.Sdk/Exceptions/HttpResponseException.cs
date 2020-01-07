using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class HttpResponseException : Exception
    {
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
