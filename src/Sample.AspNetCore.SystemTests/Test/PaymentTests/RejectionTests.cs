using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Test.Helpers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class RejectionTests : Base.PaymentTests
    {
        public RejectionTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, PaymentMethods.Card })]
        public void RejectedFlowPayment(Product[] products, PayexInfo payexInfo)
        {
        }
    }
}