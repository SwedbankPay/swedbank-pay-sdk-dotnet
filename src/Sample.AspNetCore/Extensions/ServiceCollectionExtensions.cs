using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwedbankPayClient(this IServiceCollection services,
                                                              IConfiguration configuration,
                                                              string clientName)
        {
            var swedbankPayConfigsection = configuration.GetSection($"SwedbankPayOptions:{clientName}");
            services.Configure<SwedbankPayOptions>(clientName, swedbankPayConfigsection);

            var swedBankPayOptions = swedbankPayConfigsection.Get<SwedbankPayOptions>();
            swedBankPayOptions.Token = configuration["Token"];

            services.AddHttpClient<SwedbankPayClient>(s =>
            {
                s.BaseAddress = swedBankPayOptions.ApiBaseUrl;
                s.DefaultRequestHeaders.Add("Authorization", $"Bearer {swedBankPayOptions.Token}");
            }).AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            }));

            services.AddTransient(s => swedBankPayOptions);

            return services;
        }
    }
}