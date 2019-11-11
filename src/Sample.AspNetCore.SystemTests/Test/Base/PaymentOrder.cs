using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class PaymentOrder
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string State { get; set; }
        public string Operation { get; set; }
    }
}
