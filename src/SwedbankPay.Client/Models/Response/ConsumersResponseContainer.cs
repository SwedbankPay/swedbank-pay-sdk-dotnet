using System;
using System.Collections.Generic;
using System.Text;
using SwedbankPay.Client.Resources;

namespace SwedbankPay.Client.Models.Response
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
