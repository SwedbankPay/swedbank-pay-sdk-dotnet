using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotGetBillingDetailsException : SdkException
    {
        public CouldNotGetBillingDetailsException(HttpResponseMessage httpResponseMessage, string uri, ProblemsContainer problems)
            : base(httpResponseMessage, problems.ToString())
        {
            Problems = problems;
            Uri = uri;
        }


        public CouldNotGetBillingDetailsException(HttpResponseMessage httpResponseMessage, string uri)
            : base(httpResponseMessage, "Could not find billing details for the given uri")
        {
            Problems = new ProblemsContainer(nameof(uri), "Could not find billing details for the given uri");
            Uri = uri;
        }


        public ProblemsContainer Problems { get; }
        public string Uri { get; }
    }
}