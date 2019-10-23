namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using SwedbankPay.Sdk.Models;

    public class CouldNotAuthorizePaymentException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Id { get; }

        public CouldNotAuthorizePaymentException(string id, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }

        public CouldNotAuthorizePaymentException(string id, string key, string value) : this(id, new ProblemsContainer(key, value))
        {
        }
    }
}