using System.Net.Http.Headers;

using SwedbankPay.Sdk.Infrastructure;
using SwedbankPay.Sdk.PaymentOrder.Urls;
using SwedbankPay.Sdk.Tests.TestHelpers;

namespace SwedbankPay.Sdk.Tests;

public abstract class ResourceTestsBase
{
    protected ISwedbankPayClient Sut;
    
    protected readonly Urls Urls;

    protected readonly string PayeeId;

    protected ResourceTestsBase()
    {
        var connectionSettings = TestHelper.GetSwedbankPayConnectionSettings(Environment.CurrentDirectory);
        Urls = TestHelper.GetUrls(Environment.CurrentDirectory);
        PayeeId = connectionSettings.PayeeId ?? "";
        var httpClient = new HttpClient
        {
            BaseAddress = connectionSettings.ApiBaseUrl
        };
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectionSettings.Token);

        Sut = new SwedbankPayClient(httpClient);
    }
}