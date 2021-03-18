namespace SwedbankPay.Sdk.Consumers
{
    internal class ConsumersResponseDto
    {
        public OperationListDto Operations { get; set; }

        public string Token { get; set; }
    }
}