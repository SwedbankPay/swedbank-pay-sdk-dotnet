namespace SwedbankPay.Sdk.Consumers
{
    using System.Collections.Generic;

    public class ConsumersResponse
    {
        public string Token { get; protected set; }

        public List<HttpOperation> Operations { get; protected set; } = new List<HttpOperation>();
    }
}
