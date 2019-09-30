using SwedbankPay.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwedbankPay.Client.Models.Request;

namespace SwedbankPay.Client.Exceptions
{
    public class CouldNotInitiateConsumerSessionException : Exception
    {
        public ProblemsContainer Problems { get; }
        public ConsumerResourceRequest Consumer { get; }

        public CouldNotInitiateConsumerSessionException(ConsumerResourceRequest consumer, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Consumer = consumer;
        }
    }
}
