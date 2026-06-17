using System.Net.Http.Headers;

using Microsoft.Extensions.DependencyInjection;

using SwedbankPay.Sdk.Infrastructure;

namespace SwedbankPay.Sdk.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures the named HttpClient for the <seealso cref="SwedbankPay.Sdk.Infrastructure.SwedbankPayClient"/> with the specified <paramref name="baseAddress"/> and <paramref name="authenticationToken"/>.
    /// This also configures a default request header for JSON-based API communication and sets the authentication token.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="baseAddress">The base address of the SwedbankPay API.</param>
    /// <param name="authenticationToken">The authentication token for authorizing requests to the SwedbankPay API.</param>
    /// <returns>A configured <see cref="IHttpClientBuilder"/> instance for the SwedbankPay client.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="authenticationToken"/> is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="baseAddress"/> is not well-formed or not an absolute URI.</exception>
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
    /// Configures the named HttpClient for the <seealso cref="SwedbankPay.Sdk.Infrastructure.SwedbankPayClient"/> with the specified <paramref name="baseAddress"/>.
    /// This also configures a default request header for JSON-based API communication.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="baseAddress">The base address of the SwedbankPay API.</param>
    /// <returns>A configured <see cref="IHttpClientBuilder"/> instance for the SwedbankPay client.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="baseAddress"/> is not well-formed or not an absolute URI.</exception>
    public static IHttpClientBuilder AddSwedbankPayClient(this IServiceCollection services, Uri baseAddress)
    {
        if (Uri.IsWellFormedUriString(baseAddress.OriginalString, UriKind.Absolute) == false)
        {
            throw new ArgumentException($"{nameof(baseAddress)} is not a well formed and absolute {nameof(Uri)}.");
        }

        return AddClientAndHandler(services, a =>
        {
            a.BaseAddress = baseAddress;
            a.DefaultRequestHeaders.Add("Accept", "application/json;version=3.1");
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
        services.AddScoped<ISwedbankPayClientFactory, SwedbankPayClientFactory>();
        
        services.AddScoped<LoggingDelegatingHandler>();
        
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
        services.AddScoped<ISwedbankPayClientFactory, SwedbankPayClientFactory>();
        
        services.AddScoped<LoggingDelegatingHandler>();

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