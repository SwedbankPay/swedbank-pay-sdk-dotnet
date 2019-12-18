using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotPostTransactionException : SdkException
    {
        public CouldNotPostTransactionException(HttpResponseMessage httpResponseMessage, string id, ProblemsContainer problems)
            : base(httpResponseMessage, problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}