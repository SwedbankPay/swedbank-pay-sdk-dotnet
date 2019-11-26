namespace SwedbankPay.Sdk.Tests.Json
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SwedbankPay.Sdk.JsonSerialization;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Payments;

    using Xunit;

    public class CustomCurrencyCodeConverterTests
    {
        private string currencyCode = "SEK";

        [Fact]
        public void CanDeSerialize_CurrencyCode()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("currency", this.currencyCode);

            //ACT
            var result = JsonConvert.DeserializeObject<CurrencyCode>(jsonObject.ToString(), JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.currencyCode, result.ToString());
        }

        [Fact]
        public void CanSerialize_CurrencyCode()
        {
            //ARRANGE
            var paymentOrderRequest = new PaymentOrderRequest
            {
                Currency = new CurrencyCode("SEK")
            };

            //ACT
            var result = JsonConvert.SerializeObject(paymentOrderRequest, JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Currency", StringComparison.InvariantCultureIgnoreCase, out var code);
            //ASSERT
            Assert.Equal(this.currencyCode, code);
        }
    }
}