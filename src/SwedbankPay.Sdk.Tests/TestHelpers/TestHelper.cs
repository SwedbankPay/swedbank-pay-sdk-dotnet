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
                .Build();

#elif RELEASE

            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddEnvironmentVariables()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "SwedbankPayConnectionSettings:Token", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:Token", EnvironmentVariableTarget.User)},
                    { "SwedbankPayConnectionSettings:ApiBaseUrl", Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings:ApiBaseUrl", EnvironmentVariableTarget.User) },
                    { "Urls:TermsOfServiceUrl", Environment.GetEnvironmentVariable("Urls:TermsOfServiceUrl", EnvironmentVariableTarget.User) },
                    { "Urls:CallBackUrl", Environment.GetEnvironmentVariable("Urls:CallBackUrl", EnvironmentVariableTarget.User) },
                    { "Urls:CancelUrl", Environment.GetEnvironmentVariable("Urls:CancelUrl", EnvironmentVariableTarget.User)},
                    { "Urls:CompleteUrl", Environment.GetEnvironmentVariable("Urls:CompleteUrl", EnvironmentVariableTarget.User) },
                    { "Urls:LogoUrl", Environment.GetEnvironmentVariable("Urls:LogoUrl", EnvironmentVariableTarget.User) },
                    { "Urls:HostUrls", Environment.GetEnvironmentVariable("Urls:HostUrls", EnvironmentVariableTarget.User) }
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
            
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Urls")
                .Bind(configuration);

            return new Urls(configuration.HostUrls, configuration.CompleteUrl, configuration.TermsOfServiceUrl, configuration.CancelUrl,
                            configuration.PaymentUrl, configuration.CallbackUrl, configuration.LogoUrl);
        }
    }
}