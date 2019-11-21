namespace SwedbankPay.Sdk.Tests
{
    using SwedbankPay.Sdk;

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public abstract class ResourceTestsBase
    {
        protected SwedbankPayClient Sut;

        protected ResourceTestsBase()
        {
            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://www.example.com/"),
                CompletePageUrl = new Uri("https://www.example.com/"),
                CancelPageUrl = new Uri("https://www.example.com/"),
                TermsOfServiceUrl = new Uri("https://www.example.com/"),
                PaymentUrl = new Uri("https://www.example.com/"),
                MerchantId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
                HostUrls = new List<Uri>(){new Uri("https://www.example.com/") }
            };

            var client = new HttpClient { BaseAddress = swedbankPayOptions.ApiBaseUrl };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", swedbankPayOptions.Token);
            this.Sut = new SwedbankPayClient(swedbankPayOptions, client);
        }
    }
}
