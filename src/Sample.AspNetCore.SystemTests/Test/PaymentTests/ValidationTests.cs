using Atata;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests
{
    public class ValidationTests : PaymentTests
    {
        public ValidationTests(string driverAlias)
            : base(driverAlias)
        {
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationCard(Product[] products)
        {
            GoToPayexCardPaymentFrame(products)
                .CreditCardNumber.Set("abc")
                .ExpiryDate.Set("abcd")
                .Cvc.Set("abc")
                .CreditCardNumber.Click()
                .ValidationIcons[x => x.CreditCardNumber].Should.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.BeVisible()
                .CreditCardNumber.Set(TestDataService.CreditCardNumber)
                .ExpiryDate.Set(TestDataService.CreditCardExpiratioDate)
                .Cvc.Set(TestDataService.CreditCardCvc)
                .ValidationIcons[x => x.CreditCardNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ExpiryDate].Should.Not.BeVisible();
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationInvoice(Product[] products)
        {
            GoToPayexInvoicePaymentFrame(products)
                .PersonalNumber.Set("abc")
                .Email.Set("abc")
                .PhoneNumber.Set("abc")
                .ZipCode.Set("abc")
                .PersonalNumber.Click()
                .ValidationIcons[x => x.PersonalNumber].Should.BeVisible()
                .ValidationIcons[x => x.Email].Should.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.BeVisible()
                .PersonalNumber.Set(TestDataService.PersonalNumberShort)
                .Email.Set(TestDataService.Email)
                .PhoneNumber.Set(TestDataService.PhoneNumber)
                .ZipCode.Set(TestDataService.ZipCode)
                .ValidationIcons[x => x.PersonalNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.Email].Should.Not.BeVisible()
                .ValidationIcons[x => x.PhoneNumber].Should.Not.BeVisible()
                .ValidationIcons[x => x.ZipCode].Should.Not.BeVisible();
        }


        [Test]
        [TestCaseSource(nameof(TestData), new object[] { true, null })]
        public void FieldValidationSwish(Product[] products)
        {
            GoToPayexSwishPaymentFrame(products);
        }
    }
}