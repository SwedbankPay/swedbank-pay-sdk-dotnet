using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotFindPaymentException : Exception
    {
        public CouldNotFindPaymentException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotFindPaymentException(string id)
            : base("Could not find payment for the given id")
        {
            Problems = new ProblemsContainer(nameof(id), "Could not find payment for the given id");
            Id = id;
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}