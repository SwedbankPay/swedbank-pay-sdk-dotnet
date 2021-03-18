using SwedbankPay.Sdk.Tests.TestHelpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SwedbankPay.Sdk.Tests
{
    public abstract class ResourceTestsBase
    {
        protected ISwedbankPayClient Sut;

        protected ISwedbankPayClient SutMobilePay;

        protected readonly IUrls urls;

        protected readonly string payeeId;

        private readonly SwedbankPayConnectionSettings connectionSettings;

        protected ResourceTestsBase()
        {
            this.connectionSettings = TestHelper.GetSwedbankPayConnectionSettings(Environment.CurrentDirectory);
            this.urls = TestHelper.GetUrls(Environment.CurrentDirectory);
            this.payeeId = this.connectionSettings.PayeeId;
            var httpClient = new HttpClient { BaseAddress = this.connectionSettings.ApiBaseUrl };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.connectionSettings.Token);

            this.Sut = new SwedbankPayClient(httpClient);


            var httpClientMobilePay = new HttpClient { BaseAddress = this.connectionSettings.ApiBaseUrl };
            httpClientMobilePay.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.connectionSettings.TokenMobilePay);

            this.SutMobilePay = new SwedbankPayClient(httpClientMobilePay);
        }
    }
}