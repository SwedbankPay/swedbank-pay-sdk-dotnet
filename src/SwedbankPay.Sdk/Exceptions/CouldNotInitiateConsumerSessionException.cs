using System;

using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotInitiateConsumerSessionException : Exception
    {
        public CouldNotInitiateConsumerSessionException(ConsumersRequest consumer, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Consumer = consumer;
        }


        public ConsumersRequest Consumer { get; }
        public ProblemsContainer Problems { get; }
    }
}