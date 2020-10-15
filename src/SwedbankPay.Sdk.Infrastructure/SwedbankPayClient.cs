using System;
using System.Net;
using System.Net.Http;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.PaymentInstruments;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
        private readonly HttpClient httpClient;

        public SwedbankPayClient(HttpClient httpClient, IPaymentOrdersResource paymentOrders, IConsumersResource consumers, IPaymentsResource payments)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            if (this.httpClient.BaseAddress == null)
                throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");

            if (this.httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
                throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");

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
        public IPaymentsResource Payments { get; }
    }
}