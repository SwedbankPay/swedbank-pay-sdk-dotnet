using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotGetBillingDetailsException : Exception
    {
        public CouldNotGetBillingDetailsException(string uri, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Uri = uri;
        }


        public CouldNotGetBillingDetailsException(string uri)
            : base("Could not find billing details for the given uri")
        {
            Problems = new ProblemsContainer(nameof(uri), "Could not find billing details for the given uri");
            Uri = uri;
        }


        public ProblemsContainer Problems { get; }
        public string Uri { get; }
    }
}