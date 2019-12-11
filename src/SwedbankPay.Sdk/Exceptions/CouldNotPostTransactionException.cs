using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotPostTransactionException : Exception
    {
        public CouldNotPostTransactionException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}