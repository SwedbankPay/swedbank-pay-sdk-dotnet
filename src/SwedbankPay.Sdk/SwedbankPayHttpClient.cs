namespace SwedbankPay.Sdk
{
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    using SwedbankPay.Sdk.Exceptions;

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    internal class SwedbankPayHttpClient
    {
        private readonly HttpClient client;
        private readonly ILogger logger;
       
        internal SwedbankPayHttpClient(HttpClient client, ILogger logger)
        {
            this.client = client;
            this.logger = logger;
        }

        internal async Task<TResponse> HttpPost<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return await HttpRequest<TResponse>(HttpMethod.Post, url, onError, payload);
        }

        internal async Task<TResponse> HttpPatch<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return await HttpRequest<TResponse>(HttpMethod.Patch, url, onError, payload);
        }

        internal async Task<TResponse> HttpGet<TResponse>(string url, Func<ProblemsContainer, Exception> onError) where TResponse : new()
        {
            return await HttpRequest<TResponse>(HttpMethod.Get, url, onError);
        }

        /// <summary>
        /// Updates the rest request with parameters.
        /// </summary>
        /// <param name="msg">The http request message.</param>
        /// <param name="request">The request.</param>
        private void UpdateRequest(HttpRequestMessage msg, object request)
        {
            if (request != null)
            {
                var content = JsonConvert.SerializeObject(request, JsonSerialization.JsonSerialization.settings);
                msg.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }
            msg.Headers.Add("Accept", "application/json");
        }

        internal async Task<T> HttpRequest<T>(string httpMethod, string url, Func<ProblemsContainer, Exception> onError, object payload = null) where T : new()
        {
            return await HttpRequest<T>(new HttpMethod(httpMethod), url, onError, payload);
        }

        internal async Task<T> HttpRequest<T>(HttpMethod httpMethod, string url, Func<ProblemsContainer, Exception> onError, object payload = null) where T : new()
        {
            var msg = new HttpRequestMessage(httpMethod, url);

            UpdateRequest(msg, payload);

            HttpResponseMessage response;
            try
            {
                response = await this.client.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
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
                this.logger.LogInformation(res);
                return JsonConvert.DeserializeObject<T>(res, JsonSerialization.JsonSerialization.settings);
            }

            var responseMessage = await response.Content.ReadAsStringAsync();
            this.logger.LogInformation(responseMessage);
            ProblemsContainer problems;
            if (!string.IsNullOrEmpty(responseMessage) && IsValidJson(responseMessage))
            {
                problems = JsonConvert.DeserializeObject<ProblemsContainer>(responseMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                problems = new ProblemsContainer("id", "Not found");
            }
            else
            {
                problems = new ProblemsContainer("Other", $"Response when calling SwedbankPay was: '{response.StatusCode}'");
            }

            var ex = onError(problems);
            throw ex;
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

        private static bool IsValidJson(string responseString)
        {
            responseString = responseString.Trim();
            if ((responseString.StartsWith("{") && responseString.EndsWith("}")) || (responseString.StartsWith("[") && responseString.EndsWith("]")))
            {
                try
                {
                    JToken.Parse(responseString);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        private string GetRequestBody(object request)
        {
            var requestBody = string.Empty;
            if (request != null)
            {
                requestBody = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
                });
            }
            return requestBody;
        }
    }
}
