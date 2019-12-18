using System;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        ///     Get request in raw json
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        internal async Task<string> GetRaw(Uri url)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
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
                var indentedResponseBody = JToken.Parse(httpResponseBody).ToString(Formatting.Indented);
                this.logger.LogInformation(indentedResponseBody);
                return indentedResponseBody;
            }
            catch (HttpResponseException ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
            catch (Exception ex)
            {
                var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                throw new HttpResponseException(
                    httpResponse,
                    message : BuildErrorMessage(httpResponseBody),
                    innerException : ex);
            }
        }


        /// <summary>
        ///     Send a HttpRequest and Process HttpResponse for a url
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        internal async Task<TResponse> HttpGet<TResponse>(Uri url)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(HttpMethod.Get, url);
        }


        /// <summary>
        ///     Send the HttpRequest and Process HttpResponse
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpMethod"></param>
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        internal async Task<TResponse> SendHttpRequestAndProcessHttpResponse
            <TResponse>(HttpMethod httpMethod,
                        Uri url,
                        object payload = null)
            where TResponse : new()
        {
            var requestMessage = new HttpRequestMessage(httpMethod, url);

            if (payload != null)
            {
                var content = JsonConvert.SerializeObject(payload, JsonSerialization.JsonSerialization.Settings);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            requestMessage.Headers.Add("Accept", "application/json");

            return await SendHttpRequestAndProcessHttpResponse<TResponse>(requestMessage);
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
            where TResponse : new()
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
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
            catch (Exception ex)
            {
                var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                throw new HttpResponseException(
                    httpResponse,
                    message : BuildErrorMessage(httpResponseBody),
                    innerException : ex);
            }
        }
    }
}