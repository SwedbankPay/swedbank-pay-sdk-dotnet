using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.Api
{
    public class PaymentOrder
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string State { get; set; }
        public CurrentPayment CurrentPayment { get; set; }
        public OrderItems OrderItems { get; set; }

    }
}
