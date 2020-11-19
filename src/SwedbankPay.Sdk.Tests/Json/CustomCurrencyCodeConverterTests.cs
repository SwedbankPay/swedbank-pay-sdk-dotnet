using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Text.Json;
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

            var jsonObject = $"{{\"currency\": \"{currencyCode}\" }}";

            //ACT
            var result = JsonSerializer.Deserialize<CurrencyCode>(jsonObject, JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(currencyCode, result.ToString());
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
            var code = obj.RootElement.GetProperty("currency").ToString();
            //ASSERT
            Assert.Equal(currencyCode, code);
        }
    }
}