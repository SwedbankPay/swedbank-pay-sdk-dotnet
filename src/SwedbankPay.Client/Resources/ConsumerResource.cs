using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SwedbankPay.Client.Exceptions;
using SwedbankPay.Client.Models;
using SwedbankPay.Client.Models.Request;
using SwedbankPay.Client.Models.Response;

namespace SwedbankPay.Client.Resources
{
    public class ConsumerResource : ResourceBase, IConsumerResource
    {
        public ConsumerResource(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger) : base(swedbankPayOptions, logger)
        {
        }

        public async Task<ConsumerResourceResponseContainer> InitiateSession(ConsumerResourceRequestContainer consumerResourceRequest)
        {
            var url = "/psp/consumers";
            
            Func<ProblemsContainer, Exception> onError = m => new CouldNotInitiateConsumerSessionException(consumerResourceRequest, m);
            consumerResourceRequest.ConsumerResourceRequest.Operation = "initiate-consumer-session";
            var res = await CreateInternalClient().HttpPost<ConsumerResourceRequestContainer, ConsumerResourceResponseContainer>(url, onError, consumerResourceRequest);

            return res;
        }

       
    }
}
