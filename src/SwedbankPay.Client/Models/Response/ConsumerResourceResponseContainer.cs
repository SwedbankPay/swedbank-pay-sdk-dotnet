using System;
using System.Collections.Generic;
using System.Text;
using SwedbankPay.Client.Resources;

namespace SwedbankPay.Client.Models.Response
{
    public class ConsumerResourceResponseContainer
    {
        public ConsumerResourceResponseContainer()
        {
        }

        public ConsumerResourceResponseContainer(ConsumerResourceResponse consumer)
        {
            ConsumerResourceResponse = consumer;
        }

        public ConsumerResourceResponse ConsumerResourceResponse { get; set; }
    }
}
