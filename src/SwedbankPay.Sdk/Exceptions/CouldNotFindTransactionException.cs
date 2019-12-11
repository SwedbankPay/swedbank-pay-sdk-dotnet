using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotFindTransactionException : Exception
    {
        public CouldNotFindTransactionException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotFindTransactionException(string id)
            : base("Could not find transaction for the given id")
        {
            Problems = new ProblemsContainer(nameof(id), "Could not find transaction for the given id");
            Id = id;
        }


        public CouldNotFindTransactionException(string id, string name, string desc)
            : this(id, new ProblemsContainer(name, desc))
        {
        }


        public CouldNotFindTransactionException(Exception inner)
            : base("Could not find transaction for the given id", inner)
        {
            Problems = new ProblemsContainer("Other", "Could not find transaction for the given id");
        }


        public string Id { get; }
        public ProblemsContainer Problems { get; }
    }
}