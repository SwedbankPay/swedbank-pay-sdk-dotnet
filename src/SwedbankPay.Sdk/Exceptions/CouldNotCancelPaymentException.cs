using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotCancelPaymentException : Exception
    {
        public CouldNotCancelPaymentException(Uri id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotCancelPaymentException(Uri id, string value)
            : this(id, new ProblemsContainer("paymentId", value))
        {
        }


        public Uri Id { get; }
        public ProblemsContainer Problems { get; }
    }
}