using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk
{
    internal class SwedbankPayHttpClient
    {
        private readonly HttpClient client;
        private readonly ILogger logger;


        internal SwedbankPayHttpClient(HttpClient client, ILogger logger)
        {
            this.client = client;
            this.logger = logger;
        }


        /// <summary>
        ///     Send a HttpGet and Process HttpResponse for a url
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        internal async Task<TResponse> HttpGet<TResponse>(Uri url)
        {
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Get, url);
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(httpRequestMessage);
        }


        /// <summary>
        ///     Send a HttpPatch and Process HttpResponse for a url
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        internal async Task<TResponse> HttpPatch
            <TResponse>(Uri url, object payload)
            where TResponse : new()
        {
            var httpRequestMessage = CreateHttpRequestMessage(new HttpMethod("PATCH"), url, payload);
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(httpRequestMessage);
        }


        /// <summary>
        ///     Send a HttpPost and Process HttpResponse for a url
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        internal async Task<TResponse> HttpPost
            <TResponse>(Uri url, object payload)
        {
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, url, payload);
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(httpRequestMessage);
        }


        /// <summary>
        ///     Send the HttpRequest and Process HttpResponse
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpRequest"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        internal async Task<TResponse> SendHttpRequestAndProcessHttpResponse
            <TResponse>(HttpRequestMessage httpRequest)
        {
            var httpResponse = await this.client.SendAsync(httpRequest);

            string BuildErrorMessage(string httpResponseBody)
            {
                return
                    $"{httpRequest.Method}: {httpRequest.RequestUri} failed with error code {httpResponse.StatusCode} using bearer token {httpRequest.Headers.Authorization.Parameter}. Response body: {httpResponseBody}";
            }

            try
            {
                var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                    throw new HttpResponseException(
                        httpResponse,
                        JsonConvert.DeserializeObject<ProblemsContainer>(httpResponseBody),
                        BuildErrorMessage(httpResponseBody));
                return JsonConvert.DeserializeObject<TResponse>(httpResponseBody, JsonSerialization.JsonSerialization.Settings);
            }
            catch (HttpResponseException ex)
            {
                this.logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                throw new HttpResponseException(
                    httpResponse,
                    message : BuildErrorMessage(httpResponseBody),
                    innerException : ex);
            }
        }


        private HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, Uri url, object payload = null)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

            if (payload != null)
            {
                var content = JsonConvert.SerializeObject(payload, JsonSerialization.JsonSerialization.Settings);
                httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            httpRequestMessage.Headers.Add("Accept", "application/json");
            return httpRequestMessage;
        }
    }
}