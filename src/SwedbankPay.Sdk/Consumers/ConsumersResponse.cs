namespace SwedbankPay.Sdk.Consumers
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ConsumersResponse
    {
        /// <summary>
        /// A session token used to initiate Checkout UI
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// The array of operation objects to choose from 
        /// </summary>
        public OperationList Operations { get; protected set; } = new OperationList();


        [JsonConstructor]
        public ConsumersResponse(string token)
        {
            Token = token;
        }


        public ConsumersResponse()
        {
        }
    }
}
