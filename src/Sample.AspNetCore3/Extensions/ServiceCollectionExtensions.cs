using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore3.Extensions
{
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddSwedbankPayClient(this IServiceCollection services, IConfiguration configuration, string clientName)
            {
                var swedbankPayConfigsection = configuration.GetSection($"SwedbankPay:{clientName}");
                services.Configure<SwedbankPayOptions>(clientName, swedbankPayConfigsection);
                services.Configure<SwedbankPayOptions>(opt => opt.Token = configuration["Token"]);
                var swedbankPayOptions = swedbankPayConfigsection.Get<SwedbankPayOptions>();
                services.AddTransient<SwedbankPayOptions>();
                services.AddTransient(s => new SwedbankPayClient(swedbankPayOptions));
                return services;
            }
        }
    
}