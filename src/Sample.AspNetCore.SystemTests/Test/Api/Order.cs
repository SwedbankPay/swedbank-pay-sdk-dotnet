namespace Sample.AspNetCore.SystemTests.Test.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Order
    {
        public PaymentOrder PaymentOrder { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
