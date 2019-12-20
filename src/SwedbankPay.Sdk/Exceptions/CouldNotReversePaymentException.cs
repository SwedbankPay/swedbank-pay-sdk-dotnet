using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotReversePaymentException : Exception
    {
        public CouldNotReversePaymentException(Uri id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotReversePaymentException(Uri id, string value)
            : this(id, new ProblemsContainer("paymentId", value))
        {
        }


        public Uri Id { get; }
        public ProblemsContainer Problems { get; }
    }
}