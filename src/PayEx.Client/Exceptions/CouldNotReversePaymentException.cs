namespace SwedbankPay.Client.Exceptions
{
    using System;
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Vipps;

    public class CouldNotReversePaymentException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Id { get; }

        public CouldNotReversePaymentException(string id, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }

        public CouldNotReversePaymentException(string id, string value) : this(id, new ProblemsContainer("paymentId", value))
        {
        }
    }
}