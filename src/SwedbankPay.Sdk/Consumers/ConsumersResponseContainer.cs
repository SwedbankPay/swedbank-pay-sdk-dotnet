namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResponseContainer
    {
        public ConsumersResponseContainer()
        {
        }


        public ConsumersResponseContainer(ConsumersResponse consumer)
        {
            ConsumersResponse = consumer;
        }


        public ConsumersResponse ConsumersResponse { get; set; }
    }
}