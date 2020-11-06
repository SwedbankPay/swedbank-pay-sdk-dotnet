namespace SwedbankPay.Sdk.Consumers
{
    public interface IConsumersResponse
    {
        /// <summary>
        ///     The array of operation objects to choose from
        /// </summary>
        public ConsumerOperations Operations { get; }

        /// <summary>
        ///     A session token used to initiate Checkout UI
        /// </summary>
        string Token { get; }
    }
}