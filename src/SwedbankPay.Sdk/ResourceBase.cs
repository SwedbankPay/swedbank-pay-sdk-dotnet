namespace SwedbankPay.Sdk;

/// <summary>
/// Abstract class to share a <seealso cref="HttpClient"/>.
/// </summary>
public class ResourceBase
{
    protected IHttpClientFactory? HttpClientFactory { get; }

    /// <summary>
    /// <seealso cref="HttpClient"/> ready to communicate with SwedbankPay.
    /// </summary>
    protected HttpClient? HttpClient { get; set; }

    /// <summary>
    /// Instantiates a derived class with a <paramref name="httpClient"/>.
    /// </summary>
    /// <param name="httpClient"><seealso cref="System.Net.Http.HttpClient"/> with authorization for the API.</param>
    /// <exception cref="ArgumentNullException"></exception>
    protected ResourceBase(HttpClient? httpClient)
    {
        ValidateHttpClient(httpClient);
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }


    protected ResourceBase(IHttpClientFactory? httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    protected HttpClient GetHttpClient(string? payeeId)
    {
        if (HttpClient != null)
        {
            return HttpClient;
        }

        if (HttpClientFactory == null)
        {
            throw new ArgumentNullException(nameof(HttpClientFactory), $"{HttpClientFactory} cannot be null");
        }
        
        if (string.IsNullOrWhiteSpace(payeeId))
        {
            throw new ArgumentNullException(nameof(payeeId), $"{payeeId} cannot be null");
        }

        var httpClient = HttpClientFactory.CreateClient(payeeId);
        ValidateHttpClient(httpClient);
        return httpClient;
    }
    
    private void ValidateHttpClient(HttpClient? httpClient)
    {
        if (httpClient == null)
        {
            throw new ArgumentNullException(nameof(httpClient));
        }
        if (httpClient.BaseAddress == null)
        {
            throw new ArgumentNullException(nameof(httpClient), $"{nameof(httpClient.BaseAddress)} cannot be null.");
        }
        if (httpClient.DefaultRequestHeaders.Authorization?.Parameter == null)
        {
            throw new ArgumentException($"Please configure the {nameof(httpClient)} with an Authorization header.");
        }
        if (!httpClient.DefaultRequestHeaders.Contains("User-Agent"))
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent.Default);
        }
    }
}