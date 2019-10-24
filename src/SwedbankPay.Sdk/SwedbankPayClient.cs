namespace SwedbankPay.Sdk
{
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.Payment;
    using SwedbankPay.Sdk.PaymentOrders;

    using System.Net;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IPaymentResource Payment { get; }
        public IConsumersResource Consumers { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions, ILogSwedbankPayHttpResponse logger = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var swedbankLogger = logger ?? new NoOpLogger();
            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, swedbankLogger);
            Payment = new PaymentResource(swedbankPayOptions, swedbankLogger);
            Consumers = new ConsumersResource(swedbankPayOptions, swedbankLogger);
        }
    }
}
