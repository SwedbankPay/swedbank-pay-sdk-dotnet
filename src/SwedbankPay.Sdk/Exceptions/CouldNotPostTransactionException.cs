namespace SwedbankPay.Sdk.Exceptions
{
    using System;

    public class CouldNotPostTransactionException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Id { get; }

        public CouldNotPostTransactionException(string id, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }
    }
}