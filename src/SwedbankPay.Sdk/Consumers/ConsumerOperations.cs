using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumerOperations : OperationsBase
    {
        public ConsumerOperations()
        {
        }


        protected ConsumerOperations(
            SerializationInfo info)
            : base()
        {
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("RedirectConsumerIdentification", typeof(HttpOperation));
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("ViewConsumerIdentification", typeof(HttpOperation));
        }


        public HttpOperation RedirectConsumerIdentification { get; internal set; }
        public HttpOperation ViewConsumerIdentification { get; internal set; }
    }
}