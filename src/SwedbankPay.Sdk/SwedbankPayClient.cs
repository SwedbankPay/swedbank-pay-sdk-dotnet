namespace SwedbankPay.Sdk
{
    using Microsoft.Extensions.Logging;

    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    using System.Net;

    using Microsoft.Extensions.Logging.Abstractions;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IPaymentsResource Payment { get; }
        public IConsumersResource Consumers { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions, ILogger logger = null)
        {
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var swedbankLogger = logger ?? NullLogger.Instance;
            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, swedbankLogger);
            Payment = new PaymentsResource(swedbankPayOptions, swedbankLogger);
            Consumers = new ConsumersResource(swedbankPayOptions, swedbankLogger);
        }
    }
}
