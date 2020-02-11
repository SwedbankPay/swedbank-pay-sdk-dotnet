using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
        private readonly HttpClient httpClient;

        public SwedbankPayClient(HttpClient httpClient, IPaymentOrdersResource paymentOrders, IConsumersResource consumers, IPaymentsResource payments)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;

            if (this.httpClient.BaseAddress == null)
                throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");

            if (this.httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
                throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");

            PaymentOrders = paymentOrders;
            Consumers = consumers;
            Payments = payments;
        }

        public IPaymentOrdersResource PaymentOrders { get; }
        public IConsumersResource Consumers { get; }
        public IPaymentsResource Payments { get; }
    }
}