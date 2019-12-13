using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;

using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwedbankPayClient(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            var swedbankPayConSettings = configuration.GetSection("SwedbankPayConnectionSettings");
            services.Configure<SwedbankPayConnectionSettings>(swedbankPayConSettings);

            var swedBankPayOptions = swedbankPayConSettings.Get<SwedbankPayConnectionSettings>();
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