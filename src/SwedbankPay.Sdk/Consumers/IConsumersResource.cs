using System;
using System.Threading.Tasks;


namespace SwedbankPay.Sdk.Consumers
{
    public interface IConsumersResource
    {
        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        Task<BillingDetails> GetBillingDetails(Uri url);


        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        Task<ShippingDetails> GetShippingDetails(Uri url);


        /// <summary>
        ///     Payer identification is done through this operation. The more information that is provided, the easier an
        ///     identification process for the payer.
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="SwedbankPay.Sdk.Exceptions.HttpResponseException"></exception>
        /// <returns></returns>
        Task<Consumer> InitiateSession(ConsumersRequest consumersRequest);
    }
}