using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NSubstitute;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Tests.TestHelpers;

namespace SwedbankPay.Sdk.Tests
{
    public abstract class ResourceTestsBase
    {
        protected ISwedbankPayClient Sut;

        protected readonly Urls urls;

        private readonly SwedbankPayConnectionSettings connectionSettings;
        
        protected ResourceTestsBase()
        {
            this.connectionSettings = TestHelper.GetSwedbankPayConnectionSettings(Environment.CurrentDirectory);
            this.urls = TestHelper.GetUrls(Environment.CurrentDirectory);
            var httpClient = new HttpClient { BaseAddress = this.connectionSettings.ApiBaseUrl };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.connectionSettings.Token);
            
            this.Sut = new SwedbankPayClient(httpClient,
                                             new PaymentOrdersResource(httpClient),
                                             new ConsumersResource(httpClient),
                                             new PaymentsResource(httpClient));
        }
    }
}