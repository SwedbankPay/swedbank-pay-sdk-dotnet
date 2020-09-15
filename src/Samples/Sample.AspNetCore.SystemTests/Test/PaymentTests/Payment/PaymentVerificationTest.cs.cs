using System;
using System.Collections.Generic;
using System.Text;
using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.Test.Helpers;


namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
    class PaymentVerificationTest: Base.PaymentTests
    {
        public PaymentVerificationTest(string driverAlias)
            : base(driverAlias)
        {
        }

        [Test]
        [Retry(3)]
        [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
        public void Payment_Card_Verify(Product[] products, PayexInfo payexInfo)
        {
            GoToVerifyPage();
            var verifyPage = GoToVerifyPage();
            verifyPage.VerifyButton.ClickAndGo();
            var paymentPage = verifyPage.VerifyButton.ClickAndGo();
            paymentPage.FillInCreditCardInfo()

        }

    }
}
