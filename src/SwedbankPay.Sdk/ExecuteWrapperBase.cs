using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            msg.Headers.Add("Accept", "application/json");
        }
    }
}
