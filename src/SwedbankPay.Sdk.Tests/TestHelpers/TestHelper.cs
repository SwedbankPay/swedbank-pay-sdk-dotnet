using System.Reflection;

using Microsoft.Extensions.Configuration;

using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Tests.TestHelpers;

public static class TestHelper
{
    public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
    {
        return new ConfigurationBuilder()
            .SetBasePath(outputPath)
            .AddJsonFile("appsettings.json", true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
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
    
    public static Urls GetUrls(string outputPath)
    {
        var configuration = new UrlsOptions();

        var iConfig = GetIConfigurationRoot(outputPath);

        iConfig
            .GetSection("Urls")
            .Bind(configuration);
        
        return new Urls(configuration.HostUrls, configuration.CompleteUrl!, configuration.CallbackUrl!)
        {
            LogoUrl = configuration.LogoUrl,
            PaymentUrl = configuration.PaymentUrl,
            CancelUrl = configuration.CancelUrl
        };
    }
}