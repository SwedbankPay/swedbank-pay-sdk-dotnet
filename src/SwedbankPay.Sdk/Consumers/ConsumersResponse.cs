namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResponse
    {
        public ConsumersResponse(string token)
        {
            Token = token;
        }


        public ConsumersResponse()
        {
        }


        /// <summary>
        ///     The array of operation objects to choose from
        /// </summary>
        public OperationList Operations { get; protected set; } = new OperationList();

        /// <summary>
        ///     A session token used to initiate Checkout UI
        /// </summary>
        public string Token { get; }
    }
}