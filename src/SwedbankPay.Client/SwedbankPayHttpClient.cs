namespace SwedbankPay.Client
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using RestSharp;

    using SwedbankPay.Client.Models.Vipps;

    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using SwedbankPay.Client.Models;

    internal class SwedbankPayHttpClient
    {
        private readonly RestClient _client;
        private readonly ILogPayExHttpResponse _logger;

        internal SwedbankPayHttpClient(RestClient client, ILogPayExHttpResponse logger)
        {
            _client = client;
            _logger = logger;
        }

        internal TResponse HttpPost<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return HttpRequest<TResponse>(Method.POST, url, onError, payload);
        }

        internal TResponse HttpPatch<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return HttpRequest<TResponse>(Method.PATCH, url, onError, payload);
        }

        internal TResponse HttpGet<TResponse>(string url, Func<ProblemsContainer, Exception> onError) where TResponse : new()
        {
            return HttpRequest<TResponse>(Method.GET, url, onError);
        }

        /// <summary>
        /// Updates the rest request with parameters.
        /// </summary>
        /// <param name="restRequest">The rest request.</param>
        /// <param name="request">The request.</param>
        private void UpdateRestRequest(RestRequest restRequest, object request)
        {
            if (request != null)
            {
                var jsonString = Utils.GetRequestBody(request);
                var json = SimpleJson.SimpleJson.DeserializeObject(jsonString);
                restRequest.AddJsonBody(json);
            }

            restRequest.AddHeader("Content-Type", "application/json");
        }

        private T HttpRequest<T>(Method httpMethod, string url, Func<ProblemsContainer, Exception> onError, object payload = null) where T : new()
        {
            var request = new RestRequest(url, httpMethod);
            UpdateRestRequest(request, payload);

            var response = _client.Execute<T>(request);

            if (response.IsSuccessful)
            {
                _logger.LogPayExResponse(response.Content);
                return response.Data;
            }

            ProblemsContainer problems;
            if (!string.IsNullOrEmpty(response?.Content) && IsValidJson(response.Content))
            {
                problems = JsonConvert.DeserializeObject<ProblemsContainer>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                problems = new ProblemsContainer("id", "Not found");
            }
            else
            {
               //IEnumerable<string> customHeader = null;
                //_client.DefaultRequestHeaders.TryGetValues("X-Payex-ClientName", out customHeader);
                //var aggr = customHeader != null ? customHeader.Aggregate((x, y) => x + "," + y) : "no-name";
                problems = new ProblemsContainer("Other", $"Response when calling SwedbankPay  was: '{response.StatusCode}'");
            }

            var ex = onError(problems);
            throw ex;
        }


        internal string GetRaw(string url)
        {
            var request = new RestRequest(url, Method.GET);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
               var res = JToken.Parse(response.Content).ToString(Formatting.Indented);
               _logger.LogPayExResponse(res);
               return res;
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
    }
}
