namespace SwedbankPay.Sdk.Tests.UnitTests
{
    using System;

    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    using Xunit;

    public class CurrencyCodeTests
    {
       
        [Theory]
        [InlineData("SE")]
        [InlineData("NOKK")]
        [InlineData("USDOL")]
        
        public void ThrowsArgumentException_WhenGivenInvalidCurrencyCode(string currencyCode)
        {
            //ASSERT
            Assert.Throws<ArgumentException>(nameof(currencyCode), () => new CurrencyCode(currencyCode));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenGivenNullOrEmptyCurrencyCode()
        {
            //ASSERT
            Assert.Throws<ArgumentNullException>("currencyCode", () => new CurrencyCode(""));
        }



        [Theory]
        [InlineData("SEK")]
        [InlineData("NOK")]
        [InlineData("USD")]
        [InlineData("EUR")]
        [InlineData("DKK")]
        public void CreateNewCurrencyCode_DoesNotThrow_WhenGivenValidCurrencyCode(string currencyCode)
        {
            //ACT
            var ex = Record.Exception(() => new CurrencyCode(currencyCode));

            //ASSERT
            Assert.Null(ex);
        }
    }
}