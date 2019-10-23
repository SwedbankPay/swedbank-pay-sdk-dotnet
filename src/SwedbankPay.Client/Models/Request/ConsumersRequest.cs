using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Client.Models.Request
{
    public class ConsumersRequest
    {
        public string Operation { get; internal set; }
        public string Msisdn { get; set; }
        public string Email { get; set; }

        public string ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
