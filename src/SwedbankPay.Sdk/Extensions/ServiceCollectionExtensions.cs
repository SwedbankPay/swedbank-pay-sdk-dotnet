using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            return services.AddHttpClient(nameof(SwedbankPayClient), configureClient);
        }

        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
        {
            return services.AddHttpClient(nameof(SwedbankPayClient), configureClient);
        }
    }
}
