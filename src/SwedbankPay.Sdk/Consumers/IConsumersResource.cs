namespace SwedbankPay.Sdk.Consumers
{
    using System.Threading.Tasks;

    public interface IConsumersResource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotInitiateConsumerSessionException"></exception>
        /// <returns></returns>
        Task<Consumer> InitiateSession(ConsumersRequest consumersRequest);

        Task<ShippingDetails> GetShippingDetails(string url);
        Task<BillingDetails> GetBillingDetails(string url);
    }


}
