using Microsoft.Extensions.DependencyInjection;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the named HttpClient <seealso cref="SwedbankPayClient"/> with <paramref name="baseAddress"/>
        ///    and default <seealso cref="HttpClient.DefaultRequestHeaders.Authorization"/> to be <paramref name="authenticationToken"/>.
        ///    This also configures up a <seealso cref="LoggingDelegatingHandler"/> to logg on exceptions.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseAddress"></param>
        /// <param name="authenticationToken"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Uri baseAddress, string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken))
                throw new ArgumentNullException(nameof(authenticationToken));
            if (Uri.IsWellFormedUriString(baseAddress.OriginalString, UriKind.Absolute) == false)
                throw new ArgumentException($"{nameof(baseAddress)} is not a well formed and abosulte {nameof(Uri)}.");

            return AddClientAndHandler(services, a =>
            {
                a.BaseAddress = baseAddress;
                a.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticationToken);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureClient"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            return AddClientAndHandler(services, configureClient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureClient"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
        {
            return AddClientAndHandler(services, configureClient);
        }

        private static IHttpClientBuilder AddClientAndHandler(IServiceCollection services, Action<HttpClient> configureClient)
        {
            services.AddCommonDependenciesForSdk();
            services.AddScoped<LoggingDelegatingHandler>();

            services.AddHttpClient<IPaymentOrdersResource, PaymentOrdersResource>(configureClient)
                            .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IConsumersResource, ConsumersResource>( configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IPaymentsResource, PaymentsResource>(configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            return
                services.AddHttpClient<ISwedbankPayClient, SwedbankPayClient>(configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

        }

        private static IHttpClientBuilder AddClientAndHandler(IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
        {
            services.AddCommonDependenciesForSdk();
            services.AddScoped<LoggingDelegatingHandler>();

            services.AddHttpClient<IPaymentOrdersResource, PaymentOrdersResource>(configureClient)
                            .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IConsumersResource, ConsumersResource>(configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IPaymentsResource, PaymentsResource>(configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            return services
                .AddHttpClient<ISwedbankPayClient, SwedbankPayClient>(configureClient)
                .AddHttpMessageHandler<LoggingDelegatingHandler>();
        }

        private static IServiceCollection AddCommonDependenciesForSdk(this IServiceCollection services)
        {
            return services
                .AddTransient<ICardPaymentsResource, CardPaymentsResource>()
                .AddTransient<ISwishPaymentsResource, SwishPaymentsResource>();
        }
    }
}
