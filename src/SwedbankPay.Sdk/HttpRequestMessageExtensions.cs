using Newtonsoft.Json;

using System.Net.Http;
using System.Text;

namespace SwedbankPay.Sdk
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpRequestMessage AttachPayload(this HttpRequestMessage request, object payload)
        {
            if (payload != null)
            {
                var content = JsonConvert.SerializeObject(payload, JsonSerialization.JsonSerialization.Settings);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            return request;
        }
    }
}
