namespace SwedbankPay.Sdk
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    using System.Net;
    using System.Net.Http;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IPaymentsResource Payment { get; }
        public IConsumersResource Consumers { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions,
                                 HttpClient httpClient,
                                 ILogger logger = null)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            var swedbankLogger = logger ?? NullLogger.Instance;
            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, swedbankLogger, httpClient);
            Payment = new PaymentsResource(swedbankPayOptions, swedbankLogger, httpClient);
            Consumers = new ConsumersResource(swedbankPayOptions, swedbankLogger, httpClient);
        }
    }
}
