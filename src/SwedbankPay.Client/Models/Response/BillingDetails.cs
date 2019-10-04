using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SwedbankPay.Client.Models.Response
{
    public class BillingDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
        [JsonProperty("billingAddress")]
        public BillingAddress BillingAddress { get; set; }
    }
}
