namespace SwedbankPay.Sdk;

/// <summary>
/// Abstract class to share a <seealso cref="HttpClient"/>.
/// </summary>
public class ResourceBase
{
    /// <summary>
    /// <seealso cref="HttpClient"/> ready to communicate with SwedbankPay.
    /// </summary>
    protected HttpClient HttpClient { get; }

    /// <summary>
    /// Instantiates a derived class with a <paramref name="httpClient"/>.
    /// </summary>
    /// <param name="httpClient"><seealso cref="System.Net.Http.HttpClient"/> with authorization for the API.</param>
    /// <exception cref="ArgumentNullException"></exception>
    protected ResourceBase(HttpClient? httpClient)
    {
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
}