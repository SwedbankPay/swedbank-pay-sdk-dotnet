using System;
using System.Text.Json;
using SwedbankPay.Sdk.Tests.TestBuilders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomCurrencyCodeConverterTests
    {
        private readonly string currencyCode = "SEK";
        
        [Fact]
        public void CanDeSerialize_CurrencyCode()
        {
            //ARRANGE

            var jsonObject = $"{{\"currency\": \"{this.currencyCode}\" }}";

            //ACT
            var result = JsonSerializer.Deserialize<CurrencyCode>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.currencyCode, result.ToString());
        }


        [Fact]
        public void CanSerialize_CurrencyCode()
        {
            //ARRANGE
            var builder = new PaymentOrderRequestBuilder();
            var paymentOrderRequest = builder.WithTestValues(Guid.NewGuid()).Build();

            //ACT
            var result = JsonSerializer.Serialize(paymentOrderRequest.PaymentOrder, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);
            var code = obj.RootElement.GetProperty("Currency").ToString();
            //ASSERT
            Assert.Equal(this.currencyCode, code);
        }
    }
}