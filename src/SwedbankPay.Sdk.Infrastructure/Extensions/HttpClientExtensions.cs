using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.Infrastructure.Extensions;

internal static class HttpClientExtensions
{
    private static readonly JsonSerializerOptions? SerializationSettings = JsonSerialization.JsonSerialization.Settings;

    internal static async Task<T?> GetAsJsonAsync<T>(this HttpClient httpClient, Uri uri) where T : class
    {
        using var apiResponse = await httpClient.GetAsync(uri);
        var (_, body) = await ProcessResponse<T>(apiResponse, httpClient, uri);
        return body;
    }

    internal static async Task<T?> PostAsJsonAsync<T>(this HttpClient httpClient, Uri uri, object? payload)
        where T : class
    {
        var (_, body) = await httpClient.SendAndProcessAsync<T>(HttpMethod.Post, uri, payload);
        return body;
    }

    internal static async Task<T?> SendAsJsonAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri)
        where T : class
    {
        return await SendAsJsonAsync<T>(httpClient, httpMethod, uri, null);
    }

    internal static  async Task<T?> SendAsJsonAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri, object? payload)
        where T : class
    {
        var (_, body) = await httpClient.SendAndProcessAsync<T>(httpMethod, uri, payload);
        return body;
    }

    internal static async Task<(HttpStatusCode StatusCode, T? Body)> SendAndProcessAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri,
        object? payload = null)
        where T : class
    {
        using var httpRequestMessage = new HttpRequestMessage(httpMethod, uri);
        if (payload != null)
        {
            var content = JsonSerializer.Serialize(payload, SerializationSettings);
            httpRequestMessage.Content = new StringContent(content, Encoding.UTF8);
            var header = new MediaTypeHeaderValue("application/json");
            header.Parameters.Add(new NameValueHeaderValue("version", "3.1"));
            httpRequestMessage.Content.Headers.ContentType = header;
        }

        using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        return await ProcessResponse<T>(httpResponseMessage, httpClient, uri);
    }

    private static async Task<(HttpStatusCode StatusCode, T? Body)> ProcessResponse<T>(HttpResponseMessage httpResponseMessage, HttpClient httpClient, Uri uri)
        where T : class
    {
        var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            HandleUnsuccessfulResponse(httpResponseContent, httpResponseMessage, httpClient, uri);
        }

        var body = JsonSerializer.Deserialize<T>(httpResponseContent, SerializationSettings);
        return (httpResponseMessage.StatusCode, body);
    }

    private static void HandleUnsuccessfulResponse(string httpResponseContent, HttpResponseMessage httpResponseMessage, HttpClient httpClient, Uri uri)
    {
        IProblem? problemResponseDto = null;
        string? errorMessage;
        if (string.IsNullOrEmpty(httpResponseContent))
        {
            var httpStatusCode = (int)httpResponseMessage.StatusCode;
            var problem = new Problem(httpResponseContent,
                httpStatusCode,
                httpResponseContent,
                httpResponseContent);
            errorMessage = BuildErrorMessage(httpResponseContent, httpClient, httpResponseMessage);
            throw new HttpResponseException(httpResponseMessage, problem, errorMessage);
        }

        if (!string.IsNullOrEmpty(httpResponseContent))
        {
            problemResponseDto = JsonSerializer.Deserialize<ProblemDto>(httpResponseContent, SerializationSettings)?.Map();
        }

        errorMessage = BuildErrorMessage(httpResponseContent, uri, httpResponseMessage);
        var httpResponseException = new HttpResponseException(
            httpResponseMessage,
            problemResponseDto,
            errorMessage);
        httpResponseException.Data.Add(nameof(httpResponseContent), httpResponseContent);
        throw httpResponseException;
    }

    private static string BuildErrorMessage(string httpResponseBody, HttpClient httpClient,  HttpResponseMessage httpResponseMessage)
    {
        return
            $"{httpResponseMessage.RequestMessage?.Method}: {httpResponseMessage.RequestMessage?.RequestUri} failed with error code {httpResponseMessage.StatusCode} using bearer token {httpClient.DefaultRequestHeaders?.Authorization?.Parameter}. Response body: {httpResponseBody}";
    }

    private static string BuildErrorMessage(string httpResponseBody, Uri uri, HttpResponseMessage httpResponse)
    {
        return $"GET: {uri} failed with error code {httpResponse.StatusCode}. Response body: {httpResponseBody}";
    }
}
