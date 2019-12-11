using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotAuthorizePaymentException : Exception
    {
        public CouldNotAuthorizePaymentException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotAuthorizePaymentException(string id, string key, string value)
            : this(id, new ProblemsContainer(key, value))
        {
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}