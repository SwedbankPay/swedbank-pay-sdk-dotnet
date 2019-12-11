using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotReversePaymentException : Exception
    {
        public CouldNotReversePaymentException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotReversePaymentException(string id, string value)
            : this(id, new ProblemsContainer("paymentId", value))
        {
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}