using System.Net;

using SwedbankPay.Sdk.Infrastructure.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure;

public class SwedbankPayClient : ISwedbankPayClient
{
    public SwedbankPayClient(HttpClient httpClient, IPaymentOrdersResource paymentOrders)
    {
        EnsureTls12SecurityProtocol();
        ValidateHttpClient(httpClient);
        PaymentOrders = paymentOrders ?? throw new ArgumentNullException(nameof(paymentOrders));
    }

    public SwedbankPayClient(HttpClient httpClient) :
        this(httpClient, new PaymentOrdersResource(httpClient))
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

    private void ValidateHttpClient(HttpClient httpClient)
    {
        if (httpClient == null)
        {
            throw new ArgumentNullException(nameof(httpClient));
        }
        if (httpClient.BaseAddress == null)
        {
            throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");
        }
        if (httpClient.DefaultRequestHeaders.Authorization?.Parameter == null)
        {
            throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");
        }
        if (!httpClient.DefaultRequestHeaders.Contains("User-Agent"))
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent.Default);
        }
    }
}