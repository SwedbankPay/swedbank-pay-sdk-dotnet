using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Client.Models.Response
{
    public class ConsumersResponse
    {
        public string Token { get; set; }

        public List<HttpOperation> Operations { get; set; } = new List<HttpOperation>();
    }
}
