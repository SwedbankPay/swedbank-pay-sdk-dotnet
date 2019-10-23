using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SwedbankPay.Sdk.Tests")]
namespace SwedbankPay.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using RestSharp;

    internal static class Utils
    {
        public static string GetRequestBody(object request)
        {
            string requestBody = string.Empty;
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

        internal static string GetExpandQueryString<T>(T expandParameter) where T : Enum
        {
            var intValue = Convert.ToInt64(expandParameter);
            if(intValue == 0)
            {
                return string.Empty;
            }

            List<string> s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                var name = Enum.GetName(typeof(T), enumValue);
                if (expandParameter.HasFlag((T)enumValue) && name != "None" && name != "All")
                {
                    s.Add(name.ToLower());
                }
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }

        internal static THeaderValue GetHeaderResponseValue<THeaderValue>(this IRestResponse response, string name) where THeaderValue : class
        {
            return response.Headers.FirstOrDefault(x => x.Name == name)?.Value as THeaderValue;
        }
    }
}
