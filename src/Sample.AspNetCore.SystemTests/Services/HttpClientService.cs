namespace Sample.AspNetCore.SystemTests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpClientService
    {
        private HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", System.Configuration.ConfigurationManager.AppSettings["payexTestToken"]);
        }

        public async Task<string> SendGetRequest(string paymentOrderId, string expand)
        {
            if (paymentOrderId == null || expand == null)
            {
                throw new Exception($"paymentOrderId [{paymentOrderId}] or expand [{expand}] parameters cannot be null");
            }

            var response = await this.httpClient.GetAsync($"https://api.externalintegration.payex.com{paymentOrderId}?$expand={expand}");

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
