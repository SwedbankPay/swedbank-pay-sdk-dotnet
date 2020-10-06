
namespace SwedbankPay.Sdk.Consumers
{
    public interface IConsumer
    {
        ConsumersResponse ConsumersResponse { get; }
        ConsumerOperations Operations { get; }
    }
}