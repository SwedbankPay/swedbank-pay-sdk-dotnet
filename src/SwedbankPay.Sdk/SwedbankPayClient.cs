using System;
using System.Net;
using System.Net.Http;

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
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

            PaymentOrder = new PaymentOrderResource(httpClient);
            Consumers = new ConsumersResource(httpClient);
            Payment = new PaymentsResource(httpClient);
        }


        public IPaymentOrderResource PaymentOrder { get; }

        public IConsumersResource Consumers { get; }

        public IPaymentsResource Payment { get; }
    }
}