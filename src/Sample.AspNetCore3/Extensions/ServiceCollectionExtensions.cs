using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore3.Extensions
{
    using System;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwedbankPayClient(this IServiceCollection services, IConfiguration configuration, string clientName)
        {
            var swedbankPayConfigsection = configuration.GetSection($"SwedbankPayOptions:{clientName}");
            services.Configure<SwedbankPayOptions>(clientName, swedbankPayConfigsection);

            var swedBankPayOptions = swedbankPayConfigsection.Get<SwedbankPayOptions>();
            swedBankPayOptions.Token = configuration["Token"];

            services.AddHttpClient<SwedbankPayClient>(s =>
            {
                s.BaseAddress = swedBankPayOptions.ApiBaseUrl;
                s.DefaultRequestHeaders.Add("Authorization", $"Bearer {swedBankPayOptions.Token}");
            });

            services.AddTransient<SwedbankPayOptions>(s => swedBankPayOptions);

            return services;
        }


       
    }

}