namespace SwedbankPay.Sdk.Tests
{
    using System;
    using SwedbankPay.Sdk;

    public abstract class ResourceTestsBase
    {
        protected SwedbankPayClient _sut;

        protected ResourceTestsBase()
        {
            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://www.example.com/"),
                CompletePageUrl = new Uri("https://www.example.com/"),
                CancelPageUrl = new Uri("https://www.example.com/"),
                MerchantId = "91a4c8e0-72ac-425c-a687-856706f9e9a1"
            };

            _sut = new SwedbankPayClient(swedbankPayOptions);
        }
    }
}
