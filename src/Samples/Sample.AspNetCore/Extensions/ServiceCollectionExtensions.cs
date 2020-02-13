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
            swedBankPayOptions.Token = configuration["Token"];

            services.AddTransient(s => swedBankPayOptions);

            void configureClient(HttpClient a)
            {
                a.BaseAddress = swedBankPayOptions.ApiBaseUrl;
                a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", swedBankPayOptions.Token);
            }

            services
                .AddTransient<ICardPaymentsResource, CardPaymentsResource>()
                .AddTransient<ISwishPaymentsResource, SwishPaymentsResource>();
            services.AddHttpClient<IPaymentOrdersResource, PaymentOrdersResource>(configureClient);
            services.AddHttpClient<IConsumersResource, ConsumersResource>(configureClient);
            services.AddHttpClient<IPaymentsResource, PaymentsResource>(configureClient);

            return services;
        }
    }
}