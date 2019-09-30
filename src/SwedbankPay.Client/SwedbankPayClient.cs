namespace SwedbankPay.Client
{
    using SwedbankPay.Client.Resources;

    using System.Net;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IPaymentResource PaymentResource { get; }
        public IConsumerResource Consumer { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var swedbankLogger = logger ?? new NoOpLogger();
            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, swedbankLogger);
            PaymentResource new PaymentResource(swedbankPayOptions, swedbankLogger);
            Consumer = new ConsumerResource(swedbankPayOptions, swedbankLogger);
        }
    }
}
