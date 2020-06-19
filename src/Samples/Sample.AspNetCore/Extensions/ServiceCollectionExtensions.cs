using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using System.Net.Http;
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

            return services;
        }
    }
}