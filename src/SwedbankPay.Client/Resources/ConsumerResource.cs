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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public async Task<ConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = "/psp/consumers";
            
            Func<ProblemsContainer, Exception> onError = m => new CouldNotInitiateConsumerSessionException(consumersRequest, m);
            consumersRequest.Operation = "initiate-consumer-session";
            var res = await CreateInternalClient().HttpPost<ConsumersRequest, ConsumersResponse>(url, onError, consumersRequest);
           
            return res;
        }
        public async Task<ShippingDetails> GetShippingDetails(string uri)
        {
            
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException($"{uri} Cannot be null or whitespace", paramName: uri);
            }
            Func<ProblemsContainer, Exception> onError = m => new CouldNotGetShippingDetailsException(uri, m);
            var request = new RestRequest(uri, Method.GET);
            
            var shippingDetails = await CreateInternalClient().HttpGet<ShippingDetails>(uri, onError);

            return shippingDetails;
        }

        public async Task<BillingDetails> GetBillingDetails(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException($"{uri} Cannot be null or whitespace", paramName: uri);
            }
            Func<ProblemsContainer, Exception> onError = m => new CouldNotGetBillingDetailsException(uri, m);
            var request = new RestRequest(uri, Method.GET);

            var billingDetails = await CreateInternalClient().HttpGet<BillingDetails>(uri, onError);

            return billingDetails;
        }
    }
}
