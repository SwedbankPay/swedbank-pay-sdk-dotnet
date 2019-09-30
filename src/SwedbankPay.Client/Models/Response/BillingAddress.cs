using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SwedbankPay.Client.Models.Response
{
    public class BillingAddress
    {
        [JsonProperty("addressee")]
        public string Addressee { get; set; }
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}
