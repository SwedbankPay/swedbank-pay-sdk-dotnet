using Atata;
using Newtonsoft.Json;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Api;
using Sample.AspNetCore.SystemTests.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class RejectionTests : PaymentTests
    {
        public RejectionTests(string driverAlias) : base(driverAlias) { }

        #region Rejection

        [Test, TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void Rejected_Flow_Payment(Product[] products, PayexInfo payexInfo)
        {

        }

        #endregion
    }
}
