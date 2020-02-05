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

        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Uri baseAddress, string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken ))
                throw new ArgumentNullException(nameof(authenticationToken));
            if (Uri.IsWellFormedUriString(baseAddress.AbsolutePath, UriKind.Absolute) == false)
                throw new ArgumentException($"{nameof(baseAddress)} is not a well formed {typeof(Uri)} string.");

            return services.AddHttpClient(nameof(SwedbankPayClient), a =>
            {
                a.BaseAddress = baseAddress;
                a.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",authenticationToken);
            });
        }
    }
}
