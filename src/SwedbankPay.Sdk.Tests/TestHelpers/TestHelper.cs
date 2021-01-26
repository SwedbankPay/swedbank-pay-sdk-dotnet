using Microsoft.Extensions.Configuration;
#if RELEASE
using System;
#endif

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public static class TestHelper
    {

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.local.json", true)
                .AddUserSecrets("55739ea0-5447-45e4-b35e-e0412f172f5f")
                .AddEnvironmentVariables()
                .Build();
        }



        public static SwedbankPayConnectionSettings GetSwedbankPayConnectionSettings(string outputPath)
        {
            var configuration = new SwedbankPayConnectionSettings();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("SwedbankPay")
                .Bind(configuration);

            return configuration;
        }


        public static IUrls GetUrls(string outputPath)
        {
            var configuration = new UrlsOptions();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Urls")
                .Bind(configuration);
            var urlsDto = new UrlsDto
            {
                CallbackUrl = configuration.CallbackUrl,
                CompleteUrl = configuration.CompleteUrl,
                HostUrls = configuration.HostUrls,
                CancelUrl = configuration.CancelUrl,
                LogoUrl = configuration.LogoUrl,
                PaymentUrl = configuration.PaymentUrl,
                TermsOfServiceUrl = configuration.TermsOfServiceUrl,
                Id = configuration.CompleteUrl.OriginalString
            };
            return new UrlsResponse(urlsDto);
        }
    }
}