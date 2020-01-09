using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public abstract class ExecuteWrapperBase
    {
        /// <summary>
        ///     Updates the rest request with parameters.
        /// </summary>
        /// <param name="msg">The http request message.</param>
        /// <param name="request">The request.</param>
        protected void UpdateRequest(HttpRequestMessage msg, object request)
        {
            if (request != null)
            {
                var content = JsonConvert.SerializeObject(request, JsonSerialization.JsonSerialization.Settings);
                msg.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }
        }
    }
}