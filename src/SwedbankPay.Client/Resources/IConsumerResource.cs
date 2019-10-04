using SwedbankPay.Client.Models.Request;
using SwedbankPay.Client.Models.Response;
using System.Threading.Tasks;
using SwedbankPay.Client.Exceptions;

namespace SwedbankPay.Client.Resources
{
    public interface IConsumerResource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumerResourceRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotInitiateConsumerSessionException"></exception>
        /// <returns></returns>
        Task<ConsumerResourceResponse> InitiateSession(ConsumerResourceRequest consumerResourceRequest);
        
        Task<ShippingDetails> GetShippingDetails(string uri);
        Task<BillingDetails> GetBillingDetails(string uri);
    }

   
}
