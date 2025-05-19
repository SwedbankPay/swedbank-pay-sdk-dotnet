using System.Net;

using SwedbankPay.Sdk.Infrastructure.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure;

public class SwedbankPayClient : ISwedbankPayClient
{
    public SwedbankPayClient(IPaymentOrdersResource paymentOrders)
    {
        EnsureTls12SecurityProtocol();
        PaymentOrders = paymentOrders ?? throw new ArgumentNullException(nameof(paymentOrders));
    }
    
    public SwedbankPayClient(HttpClient httpClient) :
        this(new PaymentOrdersResource(httpClient))
    {
    }
    
    public SwedbankPayClient(IHttpClientFactory httpClientFactory) :
        this(new PaymentOrdersResource(httpClientFactory))
    {
    }

    public IPaymentOrdersResource PaymentOrders { get; }

    private void EnsureTls12SecurityProtocol()
    {
        if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
    }
}