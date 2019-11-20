namespace Sample.AspNetCore.SystemTests.Test.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationTypes
    {

        public const string Cancel = "create-paymentorder-cancel";
        public const string Capture = "create-paymentorder-capture";
        public const string Reversal = "create-paymentorder-reversal";
        public const string Get = "paid-paymentorder";
    }
}
