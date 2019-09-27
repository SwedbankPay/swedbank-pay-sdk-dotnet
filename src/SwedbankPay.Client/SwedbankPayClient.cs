namespace SwedbankPay.Client
{
    using SwedbankPay.Client.Resources;

    using System.Net;

    public class SwedbankPayClient : ISwedbankPayClient
    {
        public IPaymentOrdersResource PaymentOrders { get; }

        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            PaymentOrders = new PaymentOrdersResource(swedbankPayOptions, logger);
        }
    }
}
