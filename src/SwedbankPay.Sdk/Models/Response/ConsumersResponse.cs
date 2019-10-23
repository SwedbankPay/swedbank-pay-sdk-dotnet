namespace SwedbankPay.Sdk.Models.Response
{
    using System.Collections.Generic;

    public class ConsumersResponse
    {
        public string Token { get; set; }

        public List<HttpOperation> Operations { get; set; } = new List<HttpOperation>();
    }
}
