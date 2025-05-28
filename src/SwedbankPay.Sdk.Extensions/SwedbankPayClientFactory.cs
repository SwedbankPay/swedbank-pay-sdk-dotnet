using System.Net.Http.Headers;

using SwedbankPay.Sdk.Infrastructure;

namespace SwedbankPay.Sdk.Extensions;

public class SwedbankPayClientFactory(IHttpClientFactory httpClientFactory) : ISwedbankPayClientFactory
{
    public ISwedbankPayClient CreateClient(string authenticationToken)
    {
        var httpClient = httpClientFactory.CreateClient(nameof(SwedbankPayClient));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
        return new SwedbankPayClient(httpClient);
    }
}