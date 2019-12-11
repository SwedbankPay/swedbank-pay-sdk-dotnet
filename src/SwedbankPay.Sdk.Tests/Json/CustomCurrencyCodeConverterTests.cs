using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var jsonObject = new JObject { { "currency", this.currencyCode } };

            //ACT
            var result = JsonConvert.DeserializeObject<CurrencyCode>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.currencyCode, result.ToString());
        }


        [Fact]
        public void CanSerialize_CurrencyCode()
        {
            //ARRANGE
            var builder = new PaymentOrderRequestBuilder();
            var paymentOrderRequest = builder.WithTestValues().Build();

            //ACT
            var result = JsonConvert.SerializeObject(paymentOrderRequest, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Currency", StringComparison.InvariantCultureIgnoreCase, out var code);
            //ASSERT
            Assert.Equal(this.currencyCode, code);
        }
    }
}