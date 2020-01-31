using System;
using System.Net.Http;
using System.Net.Http.Headers;

using SwedbankPay.Sdk.Tests.TestHelpers;

namespace SwedbankPay.Sdk.Tests
{
    public abstract class ResourceTestsBase
    {
        protected SwedbankPayClient Sut;

        protected readonly Urls urls;

        private readonly SwedbankPayConnectionSettings connectionSettings;
        
        protected ResourceTestsBase()
        {
            connectionSettings = TestHelper.GetSwedbankPayConnectionSettings(Environment.CurrentDirectory);
            urls = TestHelper.GetUrls(Environment.CurrentDirectory);
            var client = new HttpClient { BaseAddress = connectionSettings.ApiBaseUrl };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectionSettings.Token);
            Sut = new SwedbankPayClient(client);
        }
    }
}