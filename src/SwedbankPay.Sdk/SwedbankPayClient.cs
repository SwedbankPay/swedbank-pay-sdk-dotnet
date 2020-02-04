using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments.Card;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
        private readonly HttpClient httpClient;

        public SwedbankPayClient(HttpClient httpClient)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (httpClient.BaseAddress == null)
                throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");

            if (httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
                throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");

            this.httpClient = httpClient;
        }

        public async Task<Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payments.Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Payments.Swish.Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payments.Swish.Payment> CreateSwishPayment(Payments.Swish.PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payments.Swish.Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        /// <summary>
        ///     Create a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        public async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest,
                                               PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Create(paymentOrderRequest, this.httpClient, GetExpandQueryString(paymentOrderExpand));
        }

        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        public Task<PaymentOrder> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), $"{id} cannot be null");

            return GetInternalAsync(id, paymentOrderExpand);
        }

        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        private async Task<PaymentOrder> GetInternalAsync(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Get(id, this.httpClient, GetExpandQueryString(paymentOrderExpand));
        }

        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<BillingDetails> GetBillingDetails(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return GetBillingDetailsInternalAsync(url);
        }


        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<ShippingDetails> GetShippingDetails(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return GetShippingDetailsInternalAsync(url);
        }


        /// <summary>
        ///     Payer identification is done through this operation. The more information that is provided, the easier an
        ///     identification process for the payer.
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public Task<Consumer> InitiateSession(ConsumersRequest consumersRequest)
        {
            return Consumer.Initiate(consumersRequest, this.httpClient);
        }


        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<BillingDetails> GetBillingDetailsInternalAsync(Uri url)
        {
            return this.httpClient.GetAsJsonAsync<BillingDetails>(url);
        }


        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<ShippingDetails> GetShippingDetailsInternalAsync(Uri url)
        {
            return this.httpClient.GetAsJsonAsync<ShippingDetails>(url);
        }

        internal string GetExpandQueryString<T>(T expandParameter)
            where T : Enum
        {
            var intValue = Convert.ToInt64(expandParameter);
            if (intValue == 0)
                return string.Empty;

            var s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                var name = Enum.GetName(typeof(T), enumValue);
                if (expandParameter.HasFlag((T)enumValue) && name != "None" && name != "All")
                    s.Add(name.ToLower());
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }
    }
}