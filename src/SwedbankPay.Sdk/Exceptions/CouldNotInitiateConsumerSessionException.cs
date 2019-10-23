namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using SwedbankPay.Sdk.Models;
    using SwedbankPay.Sdk.Models.Request;

    public class CouldNotInitiateConsumerSessionException : Exception
    {
        public ProblemsContainer Problems { get; }
        public ConsumersRequest Consumer { get; }

        public CouldNotInitiateConsumerSessionException(ConsumersRequest consumer, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Consumer = consumer;
        }
    }
}
