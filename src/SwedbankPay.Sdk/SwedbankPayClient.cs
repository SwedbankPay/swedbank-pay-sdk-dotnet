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
        public SwedbankPayClient(SwedbankPayOptions swedbankPayOptions,
                                 HttpClient httpClient,
                                 ILogger logger = null)
        {
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            var swedbankLogger = logger ?? NullLogger.Instance;
            PaymentOrder = new PaymentOrderResource(swedbankPayOptions, swedbankLogger, httpClient);
            //Payment = new PaymentsResource(swedbankPayOptions, swedbankLogger, httpClient);
            Consumers = new ConsumersResource(swedbankPayOptions, swedbankLogger, httpClient);
        }


        public IPaymentOrderResource PaymentOrder { get; }

        //public IPaymentsResource Payment { get; }
        public IConsumersResource Consumers { get; }
    }
}