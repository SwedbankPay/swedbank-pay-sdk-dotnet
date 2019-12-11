using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Consumers
{
    public interface IConsumersResource
    {
        Task<BillingDetails> GetBillingDetails(string url);

        Task<ShippingDetails> GetShippingDetails(string url);


        /// <summary>
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotInitiateConsumerSessionException"></exception>
        /// <returns></returns>
        Task<Consumer> InitiateSession(ConsumersRequest consumersRequest);
    }
}