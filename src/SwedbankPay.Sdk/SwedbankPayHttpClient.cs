namespace SwedbankPay.Sdk
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    using RestSharp;

    using System;
    using System.Net;
    using System.Threading.Tasks;

    internal class SwedbankPayHttpClient
    {
        private readonly RestClient _client;
        private readonly ILogSwedbankPayHttpResponse _logger;

        internal SwedbankPayHttpClient(RestClient client, ILogSwedbankPayHttpResponse logger)
        {
            _client = client;
            _logger = logger;
        }

        internal async Task<TResponse> HttpPost<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return await HttpRequest<TResponse>(Method.POST, url, onError, payload);
        }

        internal async Task<TResponse> HttpPatch<TPayLoad, TResponse>(string url, Func<ProblemsContainer, Exception> onError, TPayLoad payload) where TResponse : new()
        {
            return await HttpRequest<TResponse>(Method.PATCH, url, onError, payload);
        }

        internal async Task<TResponse> HttpGet<TResponse>(string url, Func<ProblemsContainer, Exception> onError) where TResponse : new()
        {
            return await HttpRequest<TResponse>(Method.GET, url, onError);
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
                var jsonString = GetRequestBody(request);
                var json = SimpleJson.SimpleJson.DeserializeObject(jsonString);
                restRequest.AddJsonBody(json);
            }

            restRequest.AddHeader("Content-Type", "application/json");
        }

        internal async Task<T> HttpRequest<T>(Method httpMethod, string url, Func<ProblemsContainer, Exception> onError, object payload = null) where T : new()
        {
            var request = new RestRequest(url, httpMethod);
            UpdateRestRequest(request, payload);

            var response = await _client.ExecuteTaskAsync<T>(request);

            if (response.IsSuccessful)
            {
                _logger.LogSwedbankPayResponse(response.Content);
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
                problems = new ProblemsContainer("Other", $"Response when calling SwedbankPay  was: '{response.StatusCode}'");
            }

            var ex = onError(problems);
            throw ex;
        }


        internal async Task<string> GetRaw(string url)
        {
            var request = new RestRequest(url, Method.GET);
            var response = await _client.ExecuteTaskAsync(request);
            if (response.IsSuccessful)
            {
               var res = JToken.Parse(response.Content).ToString(Formatting.Indented);
               _logger.LogSwedbankPayResponse(res);
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
