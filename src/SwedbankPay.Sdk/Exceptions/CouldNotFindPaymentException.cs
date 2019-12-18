using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotFindPaymentException : SdkException
    {
        public CouldNotFindPaymentException(HttpResponseMessage httpResponseMessage, string id, ProblemsContainer problems)
            : base(httpResponseMessage, problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotFindPaymentException(HttpResponseMessage httpResponseMessage, string id)
            : base(httpResponseMessage, "Could not find payment for the given id")
        {
            Problems = new ProblemsContainer(nameof(id), "Could not find payment for the given id");
            Id = id;
        }

        public CouldNotFindPaymentException(string id)
            : base(null, "Could not find payment for the given id")
        {
            Problems = new ProblemsContainer(nameof(id), "Could not find payment for the given id");
            Id = id;
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}