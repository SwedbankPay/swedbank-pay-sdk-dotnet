using System.Net;
using System.Net.Http.Headers;

using Microsoft.Extensions.DependencyInjection;

using SwedbankPay.Sdk.Infrastructure;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures the named HttpClient <seealso cref="SwedbankPay.Sdk.Infrastructure.SwedbankPayClient"/> with <paramref name="baseAddress"/>
    ///    and default <seealso cref="Authorization"/> to be <paramref name="authenticationToken"/>.
    ///    This also configures up a <seealso cref="LoggingDelegatingHandler"/> to log on exceptions.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="baseAddress"></param>
    /// <param name="authenticationToken"></param>
    /// <returns></returns>
    public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Uri baseAddress,
        string authenticationToken)
    {
        if (string.IsNullOrWhiteSpace(authenticationToken))
        {
            throw new ArgumentNullException(nameof(authenticationToken));
        }

        if (Uri.IsWellFormedUriString(baseAddress.OriginalString, UriKind.Absolute) == false)
        {
            throw new ArgumentException($"{nameof(baseAddress)} is not a well formed and absolute {nameof(Uri)}.");
        }

        return AddClientAndHandler(services, a =>
        {
            a.BaseAddress = baseAddress;
            a.DefaultRequestHeaders.Add("Accept", "application/json;version=3.1");
            a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
        });
    }

    /// <summary>
    /// Configures the named HttpClient <seealso cref="SwedbankPay.Sdk.Infrastructure.SwedbankPayClient"/> with <paramref name="configureClient"/>.
    ///    This also configures up a <seealso cref="LoggingDelegatingHandler"/> to log on exceptions.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configureClient"></param>
    /// <returns></returns>
    public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services,
        Action<HttpClient> configureClient)
    {
        return AddClientAndHandler(services, configureClient);
    }

    /// <summary>
    /// Configures the named HttpClient <seealso cref="SwedbankPay.Sdk.Infrastructure.SwedbankPayClient"/> with <paramref name="configureClient"/>.
    ///    This also configures up a <seealso cref="LoggingDelegatingHandler"/> to log on exceptions.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configureClient"></param>
    /// <returns></returns>
    public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services,
        Action<IServiceProvider, HttpClient> configureClient)
    {
        return AddClientAndHandler(services, configureClient);
    }

    private static IHttpClientBuilder AddClientAndHandler(IServiceCollection services,
        Action<HttpClient> configureClient)
    {
        services.AddScoped<LoggingDelegatingHandler>();

        services.AddHttpClient<IPaymentOrdersResource, PaymentOrdersResource>(configureClient)
            .AddHttpMessageHandler<LoggingDelegatingHandler>();

        services.AddScoped<ISwedbankPayClient, SwedbankPayClient>(a =>
        {
            var httpClientFactory = a.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(nameof(SwedbankPayClient));
            return new SwedbankPayClient(client);
        });

        return services.AddHttpClient<SwedbankPayClient>(configureClient)
            .AddHttpMessageHandler<LoggingDelegatingHandler>();
    }

    private static IHttpClientBuilder AddClientAndHandler(IServiceCollection services,
        Action<IServiceProvider, HttpClient> configureClient)
    {
        services.AddScoped<LoggingDelegatingHandler>();

        services.AddHttpClient<IPaymentOrdersResource, PaymentOrdersResource>(configureClient)
            .AddHttpMessageHandler<LoggingDelegatingHandler>();

        services.AddScoped<ISwedbankPayClient, SwedbankPayClient>(a =>
        {
            var httpClientFactory = a.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(nameof(SwedbankPayClient));
            return new SwedbankPayClient(client);
        });

        return services.AddHttpClient<SwedbankPayClient>(configureClient)
            .AddHttpMessageHandler<LoggingDelegatingHandler>();
    }
}