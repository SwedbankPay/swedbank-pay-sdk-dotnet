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


        internal async Task<TResponse> HttpGet<TResponse>(Uri url)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(HttpMethod.Get, url);
        }


        internal async Task<TResponse> HttpPatch
            <TPayLoad, TResponse>(Uri url, TPayLoad payload)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(new HttpMethod("PATCH"), url, payload);
        }


        internal async Task<TResponse> HttpPost
            <TPayLoad, TResponse>(Uri url, TPayLoad payload)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(HttpMethod.Post, url, payload);
        }


        /// <summary>
        /// Send the HttpRequest and Process HttpResponse
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

            return await SendHttpRequestAndProcessHttpResponse<TResponse>(requestMessage, payload);
        }

        /// <summary>
        /// Send the HttpRequest and Process HttpResponse
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpRequest"></param>
        /// <param name="payload"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        internal async Task<TResponse> SendHttpRequestAndProcessHttpResponse
            <TResponse>(HttpRequestMessage httpRequest, object payload = null)
            where TResponse : new()
        {
            UpdateRequest(httpRequest, payload);

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


        /// <summary>
        ///     Updates the rest request with parameters.
        /// </summary>
        /// <param name="msg">The http request message.</param>
        /// <param name="request">The request.</param>
        private void UpdateRequest(HttpRequestMessage msg, object request)
        {
            if (request != null)
            {
                var content = JsonConvert.SerializeObject(request, JsonSerialization.JsonSerialization.Settings);
                msg.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            msg.Headers.Add("Accept", "application/json");
        }
    }
}