using System.Collections.Generic;

namespace Sample.AspNetCore.SystemTests.Test.Api
{
    public class Order
    {
        public List<Operation> Operations { get; set; }
        public PaymentOrder PaymentOrder { get; set; }
    }
}