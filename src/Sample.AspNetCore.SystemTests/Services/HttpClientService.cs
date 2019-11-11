using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Services
{
    public class HttpClientService
    {
        private HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", System.Configuration.ConfigurationManager.AppSettings["payexTestToken"]);
        }

        public async Task<string> SendGetRequest(string paymentOrderId)
        {
            if (paymentOrderId == null)
            {
                throw new Exception("paymentOrderId cannot be null");
            }

            var response = await _httpClient.GetAsync($"https://api.externalintegration.payex.com{paymentOrderId}?$expand=transactions");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                throw new Exception("Response from API was null");
            }
        }
    }
}
