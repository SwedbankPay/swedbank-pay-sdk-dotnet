using System;
using System.Net;
using System.Net.Http;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public class SwedbankPayClient : ISwedbankPayClient
    {
        public SwedbankPayClient(HttpClient httpClient,
                                 ILogger logger = null)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (httpClient.BaseAddress == null)
                throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");

            if (httpClient.DefaultRequestHeaders?.Authorization?.Parameter == null)
                throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");

            var swedbankLogger = logger ?? NullLogger.Instance;
            var swedbankPayHttpClient = new SwedbankPayHttpClient(httpClient, swedbankLogger);
            PaymentOrder = new PaymentOrderResource(swedbankPayHttpClient);
            Consumers = new ConsumersResource(swedbankPayHttpClient);
        }


        public IPaymentOrderResource PaymentOrder { get; }

        public IConsumersResource Consumers { get; }
    }
}