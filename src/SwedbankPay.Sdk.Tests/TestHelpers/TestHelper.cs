using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class TestHelper
    {

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
#if DEBUG
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets("55739ea0-5447-45e4-b35e-e0412f172f5f")
                .AddEnvironmentVariables()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "SwedbankPayConnectionSettings:Token", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:Token")},
                    { "SwedbankPayConnectionSettings:ApiBaseUrl", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:ApiBaseUrl") },
                    { "Urls:TermsOfServiceUrl", Environment.GetEnvironmentVariable("Urls:TermsOfServiceUrl") },
                    { "Urls:CallBackUrl", Environment.GetEnvironmentVariable("Urls:CallBackUrl") },
                    { "Urls:CancelUrl", Environment.GetEnvironmentVariable("Urls:CancelUrl") },
                    { "Urls:CompleteUrl", Environment.GetEnvironmentVariable("Urls:CompleteUrl") },
                    { "Urls:LogoUrl", Environment.GetEnvironmentVariable("Urls:LogoUrl") },
                    { "Urls:HostUrls:0", Environment.GetEnvironmentVariable("Urls:HostUrls:0") }
                })
                .Build();

#elif RELEASE

            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddEnvironmentVariables()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "SwedbankPayConnectionSettings:Token", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:Token")}, 
                    { "SwedbankPayConnectionSettings:ApiBaseUrl", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:ApiBaseUrl") },
                    { "Urls:TermsOfServiceUrl", Environment.GetEnvironmentVariable("Urls:TermsOfServiceUrl") },
                    { "Urls:CallBackUrl", Environment.GetEnvironmentVariable("Urls:CallBackUrl") },
                    { "Urls:CancelUrl", Environment.GetEnvironmentVariable("Urls:CancelUrl") },
                    { "Urls:CompleteUrl", Environment.GetEnvironmentVariable("Urls:CompleteUrl") },
                    { "Urls:LogoUrl", Environment.GetEnvironmentVariable("Urls:LogoUrl") },
                    { "Urls:HostUrls:0", Environment.GetEnvironmentVariable("Urls:HostUrls:0") }
                })
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
            Environment.SetEnvironmentVariable("Urls:CompleteUrl", "https://www.example.com");
            Environment.SetEnvironmentVariable("Urls:HostUrls:0", "https://www.example2.com");
            Environment.SetEnvironmentVariable("Urls:TermsOfServiceUrl", "https://www.example2.com");
            Environment.SetEnvironmentVariable("Urls:CallBackUrl", "https://www.example2.com");
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Urls")
                .Bind(configuration);

            return new Urls(configuration.HostUrls, configuration.CompleteUrl, configuration.TermsOfServiceUrl, configuration.CancelUrl,
                            configuration.PaymentUrl, configuration.CallbackUrl, configuration.LogoUrl);
        }
    }
}