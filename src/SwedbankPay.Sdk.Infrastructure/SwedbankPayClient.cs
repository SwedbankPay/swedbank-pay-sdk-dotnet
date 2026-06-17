#if NETSTANDARD2_0
using System.Net;
#endif

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

    private static void EnsureTls12SecurityProtocol()
    {
#if NETSTANDARD2_0
        // Older .NET Framework consumers (4.7.1 and earlier) consuming this assembly via
        // netstandard2.0 may default to TLS 1.0/1.1. Modern .NET (net8+) HttpClient does not
        // honour ServicePointManager at all, so the setting is compiled out there to avoid
        // the SYSLIB0014 obsolete-API warning.
        if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
#endif
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