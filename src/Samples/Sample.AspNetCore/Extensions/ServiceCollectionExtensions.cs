using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
using System;

namespace Sample.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwedbankPayClient(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            var swedbankPayConSettings = configuration.GetSection("SwedbankPay");
            services.Configure<SwedbankPayConnectionSettings>(swedbankPayConSettings);

            var swedBankPayOptions = swedbankPayConSettings.Get<SwedbankPayConnectionSettings>();
            services.AddSingleton(s => swedBankPayOptions);

            void configureClient(HttpClient a)
            {
                a.BaseAddress = swedBankPayOptions.ApiBaseUrl;
                a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", swedBankPayOptions.Token);
                Console.WriteLine(a.DefaultRequestHeaders.Authorization.Parameter);
            }

            services.AddScoped<ISwedbankPayClient, SwedbankPayClient>((a) =>
            {
                var fac = a.GetRequiredService<IHttpClientFactory>();
                var client = fac.CreateClient(nameof(SwedbankPayClient));
                return new SwedbankPayClient(client);
            });

            services.AddHttpClient<SwedbankPayClient>(configureClient);
            var a = new AuthenticationHeaderValue("Bearer", swedBankPayOptions.Token);
            Console.WriteLine($"appconfig.json -> Token: {swedBankPayOptions.Token}");
            Console.WriteLine($"appconfig.json -> Token: {a.Parameter}");
            Console.WriteLine($"appconfig.json -> ApiBaseUrl: {swedBankPayOptions.ApiBaseUrl}");

            if(swedBankPayOptions.Token == "rememberToSetThisWhenTesting")
            {
                Console.WriteLine("Token not set properly");
            }
            else
            {
                Console.WriteLine("Token replaced by environment variable");
            }

            return services;
        }
    }
}