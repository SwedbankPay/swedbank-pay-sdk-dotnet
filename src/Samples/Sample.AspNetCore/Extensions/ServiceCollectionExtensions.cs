using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;

using SwedbankPay.Sdk.Extensions;

using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using System.Net.Http;
using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.Payments;
using System.Net.Http.Headers;

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
            swedBankPayOptions.Token = "6430eee8fe8a2902f74494087ae79b9ff2e2f9d1efd3eeac1110e79d3502df24";

            services.AddTransient(s => swedBankPayOptions);

            void configureClient(HttpClient a)
            {
                a.BaseAddress = swedBankPayOptions.ApiBaseUrl;
                a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", swedBankPayOptions.Token);
            }

            services.AddScoped<ISwedbankPayClient, SwedbankPayClient>((a) =>
            {
                var fac = a.GetRequiredService<IHttpClientFactory>();
                var client = fac.CreateClient(nameof(SwedbankPayClient));
                return new SwedbankPayClient(client);
            });
            services.AddHttpClient<SwedbankPayClient>(configureClient);

            return services;
        }
    }
}