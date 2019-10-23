namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using SwedbankPay.Sdk.Models;

    public class CouldNotGetShippingDetailsException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Uri { get; }

        public CouldNotGetShippingDetailsException(string uri, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Uri = uri;
        }

        public CouldNotGetShippingDetailsException(string uri) : base("Could not find shipping details for the given uri")
        {
            Problems = new ProblemsContainer(nameof(uri), "Could not find shipping details for the given uri");
            Uri = uri;
        }
    }
}
