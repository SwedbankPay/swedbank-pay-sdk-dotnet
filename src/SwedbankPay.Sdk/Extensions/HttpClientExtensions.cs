using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsJsonAsync<T>(this HttpClient httpClient, Uri uri)
        {
            var apiResponse = await httpClient.GetAsync(uri);

            var responseString = await apiResponse.Content.ReadAsStringAsync();

            if (!apiResponse.IsSuccessStatusCode)
                throw new HttpResponseException(
                    apiResponse,
                    JsonConvert.DeserializeObject<ProblemResponse>(responseString),
                    BuildErrorMessage(responseString, uri, apiResponse));

            
            return JsonConvert.DeserializeObject<T>(responseString, JsonSerialization.JsonSerialization.Settings);
        }

        internal static async Task<T> SendAndProcessAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri, object payload)
            where T : class
        {
            using var httpRequestMessage = new HttpRequestMessage(httpMethod, uri);

            if (payload != null)
            {
                var content = JsonConvert.SerializeObject(payload, JsonSerialization.JsonSerialization.Settings);
                httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            string httpResponseBody;
            try
            {
                httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!httpResponseMessage.IsSuccessStatusCode)
                    throw new HttpResponseException(
                        httpResponseMessage,
                        JsonConvert.DeserializeObject<ProblemResponse>(httpResponseBody),
                        BuildErrorMessage(httpResponseBody, httpRequestMessage, httpResponseMessage));
                return JsonConvert.DeserializeObject<T>(httpResponseBody, JsonSerialization.JsonSerialization.Settings);
            }
            catch (HttpResponseException ex)
            {
                httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                throw new HttpResponseException(
                    httpResponseMessage,
                    message: BuildErrorMessage(httpResponseBody, httpRequestMessage, httpResponseMessage),
                    innerException: ex);
            }
        }


        private static string BuildErrorMessage(string httpResponseBody, HttpRequestMessage httpRequest, HttpResponseMessage httpResponse)
        {
            return
                $"{httpRequest.Method}: {httpRequest.RequestUri} failed with error code {httpResponse.StatusCode} using bearer token {httpRequest.Headers.Authorization.Parameter}. Response body: {httpResponseBody}";
        }

        private static string BuildErrorMessage(string httpResponseBody, Uri uri, HttpResponseMessage httpResponse)
        {
            return
                $"GET: {uri} failed with error code {httpResponse.StatusCode}. Response body: {httpResponseBody}";
        }

        public static Task<T> PostAsJsonAsync<T>(this HttpClient httpClient, Uri uri, object payload)
            where T : class
        {
            return httpClient.SendAndProcessAsync<T>(HttpMethod.Post, uri, payload);
        }

        public static Task<T> SendAsJsonAsync<T>(this HttpClient httpClient, HttpMethod httpMethod, Uri uri, object payload = null)
            where T: class
        {
            return httpClient.SendAndProcessAsync<T>(httpMethod, uri, payload);
        }
    }
}
