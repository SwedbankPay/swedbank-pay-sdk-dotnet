using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SwedbankPay.Sdk.Tests
{
    public abstract class ResourceTestsBase
    {
        protected ISwedbankPayClient Sut;

        protected readonly Urls urls;

        protected readonly Guid payeeId;

        private readonly SwedbankPayConnectionSettings connectionSettings;

        protected ResourceTestsBase()
        {
            connectionSettings = TestHelper.GetSwedbankPayConnectionSettings(Environment.CurrentDirectory);
            urls = TestHelper.GetUrls(Environment.CurrentDirectory);
            payeeId = connectionSettings.PayeeId;
            var httpClient = new HttpClient { BaseAddress = connectionSettings.ApiBaseUrl };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectionSettings.Token);

            Sut = new SwedbankPayClient(httpClient);
        }
    }
}