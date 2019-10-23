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
        /// <param name="consumersRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotInitiateConsumerSessionException"></exception>
        /// <returns></returns>
        Task<ConsumersResponse> InitiateSession(ConsumersRequest consumersRequest);
        
        Task<ShippingDetails> GetShippingDetails(string uri);
        Task<BillingDetails> GetBillingDetails(string uri);
    }

   
}
