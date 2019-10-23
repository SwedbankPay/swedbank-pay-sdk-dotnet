namespace SwedbankPay.Sdk.Resources
{
    using SwedbankPay.Sdk.Models.Request;
    using SwedbankPay.Sdk.Models.Response;
    using System.Threading.Tasks;

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
