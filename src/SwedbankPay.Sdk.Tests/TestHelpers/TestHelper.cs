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
            #if DEBUG
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets("55739ea0-5447-45e4-b35e-e0412f172f5f")
                .Build();

            #elif RELEASE

            var json = $@"{{ ""SwedbankPayConnectionSettings"": {{ ""Token"": ""{Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings.Token", EnvironmentVariableTarget.User)}""}}}}";
            var memoryJsonFile = new MemoryFileInfo("config.json", System.Text.Encoding.UTF8.GetBytes(json), DateTimeOffset.Now);
            var memoryFileProvider = new MockFileProvider(memoryJsonFile);

            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile(memoryFileProvider, "config.json", false, false)
                .Build();

            #endif
        }



        public static SwedbankPayConnectionSettings GetSwedbankPayConnectionSettings(string outputPath)
        {
            var configuration = new SwedbankPayConnectionSettings();
           
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("SwedbankPayConnectionSettings")
                .Bind(configuration);

            return configuration;
        }


        public static Urls GetUrls(string outputPath)
        {
            var configuration = new UrlsOptions();
            
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Urls")
                .Bind(configuration);

            return new Urls(configuration.HostUrls, configuration.CompleteUrl, configuration.TermsOfServiceUrl, configuration.CancelUrl,
                            configuration.PaymentUrl, configuration.CallbackUrl, configuration.LogoUrl);
        }
    }
}