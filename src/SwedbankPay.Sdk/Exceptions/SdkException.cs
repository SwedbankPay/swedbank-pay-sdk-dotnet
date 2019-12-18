using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class SdkException : Exception
    {
        public SdkException(HttpResponseMessage httpResponseMessage, Exception e)
            : base(e.Message, e.InnerException)
        {
            this.HttpResponseMessage = httpResponseMessage;
        }


        public SdkException(HttpResponseMessage httpResponseMessage, string message)
            : base(message)
        {
            this.HttpResponseMessage = httpResponseMessage;
        }


        public HttpResponseMessage HttpResponseMessage { get; }
    }
}