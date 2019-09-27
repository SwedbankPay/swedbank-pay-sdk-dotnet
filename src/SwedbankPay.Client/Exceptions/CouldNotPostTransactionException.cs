namespace SwedbankPay.Client.Exceptions
{
    using System;
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Vipps;

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