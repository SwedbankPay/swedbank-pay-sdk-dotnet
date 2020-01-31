using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Services
{
    public class HttpClientService
    {
        private readonly HttpClient httpClient;


        public HttpClientService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["payexTestToken"]);
        }


        public async Task<string> SendGetRequest(string paymentOrderId, string expand)
        {
            if (paymentOrderId == null || expand == null)
                throw new Exception($"paymentOrderId [{paymentOrderId}] or expand [{expand}] parameters cannot be null");

            var response = await httpClient.GetAsync($"https://api.externalintegration.payex.com{paymentOrderId}?$expand={expand}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }

            throw new Exception("Response from API was null");
        }
    }
}