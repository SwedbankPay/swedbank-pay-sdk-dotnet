namespace SwedbankPay.Sdk
{
    using System.Net;
    using SwedbankPay.Sdk.Consumer;
    using SwedbankPay.Sdk.Payment;
    using SwedbankPay.Sdk.PaymentOrder;
    using SwedbankPay.Sdk.Resources;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }
        public IPaymentResource Payment { get; }
        public IConsumerResource Consumer { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions, ILogSwedbankPayHttpResponse logger = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var swedbankLogger = logger ?? new NoOpLogger();
            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, swedbankLogger);
            Payment = new PaymentResource(swedbankPayOptions, swedbankLogger);
            Consumer = new ConsumerResource(swedbankPayOptions, swedbankLogger);
        }
    }
}
