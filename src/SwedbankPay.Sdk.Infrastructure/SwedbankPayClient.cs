using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Net;
using System.Net.Http;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
        private readonly HttpClient _httpClient;

        public SwedbankPayClient(HttpClient httpClient, IPaymentOrdersResource paymentOrders, IConsumersResource consumers, IPaymentInstrumentsResource payments)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            }

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            if (_httpClient.BaseAddress == null)
            {
                throw new ArgumentNullException(nameof(_httpClient), $"{nameof(_httpClient.BaseAddress)} cannot be null.");
            }

            if (_httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
            {
                throw new ArgumentException($"Please configure the {nameof(_httpClient)} with an Authorization header.");
            }

            PaymentOrders = paymentOrders ?? throw new ArgumentNullException(nameof(paymentOrders));
            Consumers = consumers ?? throw new ArgumentNullException(nameof(consumers));
            Payments = payments ?? throw new ArgumentNullException(nameof(payments));
        }

        public SwedbankPayClient(HttpClient httpClient) :
            this(
                httpClient,
                new PaymentOrdersResource(httpClient),
                new ConsumersResource(httpClient),
                new PaymentsResource(httpClient))
        { }

        public IPaymentOrdersResource PaymentOrders { get; }
        public IConsumersResource Consumers { get; }
        public IPaymentInstrumentsResource Payments { get; }
    }
}