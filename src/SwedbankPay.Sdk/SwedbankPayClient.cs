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
        public IPaymentOrderResource PaymentOrder { get; }
        public IPaymentsResource Payment { get; }
        public IConsumersResource Consumers { get; }
        //internal SwedbankPayHttpClient SwedbankPayHttpClient { get; set; }
        //internal SwedbankPayOptions Options { get; set; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions,
                                 HttpClient httpClient,
                                 ILogger logger = null)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            }

            var swedbankLogger = logger ?? NullLogger.Instance;
            PaymentOrder = new PaymentOrderResource(swedbankPayOptions, swedbankLogger, httpClient);
            Payment = new PaymentsResource(swedbankPayOptions, swedbankLogger, httpClient);
            Consumers = new ConsumersResource(swedbankPayOptions, swedbankLogger, httpClient);
            //SwedbankPayHttpClient = new SwedbankPayHttpClient(httpClient, swedbankLogger);
            //Options = swedbankPayOptions;
        }
    }
}
