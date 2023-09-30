using System.Text;
using System.Text.Json;
using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T?> GetAsJsonAsync<T>(this HttpClient httpClient, Uri uri)
    {
        var apiResponse = await httpClient.GetAsync(uri);

        var responseString = await apiResponse.Content.ReadAsStringAsync();

        if (!apiResponse.IsSuccessStatusCode)
        {
            IProblem? problemResponseDto = null;
            if (!string.IsNullOrEmpty(responseString))
            {
                problemResponseDto = JsonSerializer.Deserialize<ProblemDto>(responseString).Map();
            }

            var errorMessage = BuildErrorMessage(responseString, uri, apiResponse);
            throw new HttpResponseException(
                apiResponse,
                problemResponseDto,
                errorMessage);
        }

        return JsonSerializer.Deserialize<T>(responseString, JsonSerialization.JsonSerialization.Settings);
    }

    private static async Task<T?> SendAndProcessAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri,
        object? payload)
        where T : class
    {
        using var httpRequestMessage = new HttpRequestMessage(httpMethod, uri);

        if (payload != null)
        {
            var content = JsonSerializer.Serialize(payload, JsonSerialization.JsonSerialization.Settings);
            httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
        }

        using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        string httpResponseContent = string.Empty;
        try
        {
            httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!httpResponseMessage.IsSuccessStatusCode)
            {
                string? errorMessage;
                if (string.IsNullOrEmpty(httpResponseContent))
                {
                    var httpStatusCode = (int)httpResponseMessage.StatusCode;
                    var problem = new Problem(httpResponseContent,
                        httpResponseContent,
                        httpResponseContent,
                        httpStatusCode,
                        httpResponseContent,
                        httpResponseContent);
                    errorMessage = BuildErrorMessage(httpResponseContent);
                    throw new HttpResponseException(httpResponseMessage, problem, errorMessage);
                }

                var problemResponseDto = JsonSerializer.Deserialize<ProblemDto>(httpResponseContent,
                    JsonSerialization.JsonSerialization.Settings);
                var problemResponse = problemResponseDto?.Map();
                errorMessage = BuildErrorMessage(httpResponseContent);

                throw new HttpResponseException(
                    httpResponseMessage,
                    problemResponse,
                    errorMessage);
            }

            return JsonSerializer.Deserialize<T>(httpResponseContent, JsonSerialization.JsonSerialization.Settings);
        }
        catch (HttpResponseException ex)
        {
            ex.Data.Add(nameof(httpResponseContent), httpResponseContent);
            throw ex;
        }

        string BuildErrorMessage(string? httpResponseBody)
        {
            return
                $"{httpRequestMessage.Method}: {httpRequestMessage.RequestUri} failed with error code {httpResponseMessage.StatusCode} using bearer token {httpClient.DefaultRequestHeaders?.Authorization?.Parameter}. Response body: {httpResponseBody}";
        }
    }

    private static string BuildErrorMessage(string httpResponseBody, Uri uri, HttpResponseMessage httpResponse)
    {
        return
            $"GET: {uri} failed with error code {httpResponse.StatusCode}. Response body: {httpResponseBody}";
    }

    public static Task<T?> PostAsJsonAsync<T>(this HttpClient httpClient, Uri uri, object? payload)
        where T : class
    {
        return httpClient.SendAndProcessAsync<T>(HttpMethod.Post, uri, payload);
    }

    public static Task<T?> SendAsJsonAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri,
        object? payload = null)
        where T : class
    {
        return httpClient.SendAndProcessAsync<T>(httpMethod, uri, payload);
    }
}