using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotGetShippingDetailsException : Exception
    {
        public CouldNotGetShippingDetailsException(string uri, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Uri = uri;
        }


        public CouldNotGetShippingDetailsException(string uri)
            : base("Could not find shipping details for the given uri")
        {
            Problems = new ProblemsContainer(nameof(uri), "Could not find shipping details for the given uri");
            Uri = uri;
        }


        public ProblemsContainer Problems { get; }
        public string Uri { get; }
    }
}