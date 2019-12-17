using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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


        internal async Task<string> GetRaw(string url)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("Accept", "application/json");

            HttpResponseMessage response;
            try
            {
                response = await this.client.SendAsync(msg);
            }
            catch (HttpRequestException e)
            {
                throw new BadRequestException(e);
            }
            catch (TaskCanceledException te)
            {
                throw new ApiTimeOutException(te);
            }

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var res2 = JToken.Parse(res).ToString(Formatting.Indented);
                this.logger.LogInformation(res2);
                return res2;
            }

            return null;
        }


        internal async Task<TResponse> HttpGet<TResponse>(string url, Func<ProblemsContainer, Exception> onError)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(HttpMethod.Get, url, onError);
        }


        internal async Task<TResponse> HttpPatch
            <TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(new HttpMethod("PATCH"), url, onError, payload);
        }


        internal async Task<TResponse> HttpPost
            <TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload)
            where TResponse : new()
        {
            return await SendHttpRequestAndProcessHttpResponse<TResponse>(HttpMethod.Post, url, onError, payload);
        }


        internal async Task<TResponse> SendHttpRequestAndProcessHttpResponse
            <TResponse>(HttpMethod httpMethod, string url, Func<ProblemsContainer, Exception> onError, object payload = null)
            where TResponse : new()
        {
            var requestMessage = new HttpRequestMessage(httpMethod, url);

            return await SendHttpRequestAndProcessHttpResponse<TResponse>(requestMessage, onError, payload);
        }


        internal async Task<TResponse> SendHttpRequestAndProcessHttpResponse
            <TResponse>(HttpRequestMessage requestMessage, Func<ProblemsContainer, Exception> onError, object payload = null)
            where TResponse : new()
        {
            UpdateRequest(requestMessage, payload);

            var response = await this.client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            var responseMessage = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                this.logger.LogInformation(responseMessage);
                return JsonConvert.DeserializeObject<TResponse>(responseMessage, JsonSerialization.JsonSerialization.Settings);
            }
            
            this.logger.LogInformation(responseMessage);
            ProblemsContainer problems;
            if (!string.IsNullOrWhiteSpace(responseMessage) && IsValidJson(responseMessage))
                problems = JsonConvert.DeserializeObject<ProblemsContainer>(responseMessage);
            else if (response.StatusCode == HttpStatusCode.NotFound)
                problems = new ProblemsContainer("id", "Not found");
            else
                problems = new ProblemsContainer("Other", $"Response when calling SwedbankPay was: '{response.StatusCode}'");

            var ex = onError(problems);
            throw ex;
        }


        private static bool IsValidJson(string responseString)
        {
            responseString = responseString.Trim();
            if (responseString.StartsWith("{") && responseString.EndsWith("}")
                || responseString.StartsWith("[") && responseString.EndsWith("]"))
                try
                {
                    JToken.Parse(responseString);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            return false;
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