using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.CardPayments;

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

            PaymentOrders = paymentOrders;
            Consumers = consumers;
            Payments = payments;
        }

        public SwedbankPayClient(HttpClient httpClient)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            if (this.httpClient.BaseAddress == null)
                throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");

            if (this.httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
                throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");

            var cardPaymentsResource = new CardPaymentsResource(this.httpClient);
            var swishPaymentsResource = new SwishPaymentsResource(this.httpClient);

            PaymentOrders = new PaymentOrdersResource(this.httpClient);
            Consumers = new ConsumersResource(this.httpClient);
            Payments = new PaymentsResource(this.httpClient, cardPaymentsResource, swishPaymentsResource);
        }

        public IPaymentOrdersResource PaymentOrders { get; }
        public IConsumersResource Consumers { get; }
        public IPaymentsResource Payments { get; }
    }
}