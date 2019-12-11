using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotCancelPaymentException : Exception
    {
        public CouldNotCancelPaymentException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotCancelPaymentException(string id, string value)
            : this(id, new ProblemsContainer("paymentId", value))
        {
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}