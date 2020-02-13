using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumerOperations : OperationsBase
    {
        public ConsumerOperations(OperationList operations)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case ConsumerResourceOperations.RedirectConsumerIdentification:
                        RedirectConsumerIdentification = httpOperation;
                        break;
                    case ConsumerResourceOperations.ViewConsumerIdentification:
                        ViewConsumerIdentification = httpOperation;
                        break;
                }
            }
        }


        protected ConsumerOperations(
            SerializationInfo info)
            : base()
        {
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("RedirectConsumerIdentification", typeof(HttpOperation));
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("ViewConsumerIdentification", typeof(HttpOperation));
        }


        public HttpOperation RedirectConsumerIdentification { get; }
        public HttpOperation ViewConsumerIdentification { get; }
    }
}