using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;

using SwedbankPay.Sdk.Extensions;

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

            services.AddTransient(s => swedBankPayOptions);

            services.AddSwedbankPayClient(swedBankPayOptions.ApiBaseUrl, swedBankPayOptions.Token);

            return services;
        }
    }
}