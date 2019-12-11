using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SwedbankPay.Sdk.PaymentOrders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomAmountConverterTests
    {
        private readonly long expectedAmount = 100;


        [Fact]
        public void CanDeSerialize_Amount()
        {
            //ARRANGE

            var jsonObject = new JObject { { "xX123xxaddress", this.expectedAmount } };

            //ACT
            var result = JsonConvert.DeserializeObject<Amount>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.expectedAmount, result.Value);
        }


        [Fact]
        public void CanSerialize_Amount()
        {
            //ARRANGE
            var orderItem = new OrderItem("Test", "Test", OrderItemType.Product, "MobilePhone", 3, "pcs", Amount.FromDecimal(2), 0,
                                          Amount.FromDecimal(1), Amount.FromDecimal(2));

            //ACT
            var result = JsonConvert.SerializeObject(orderItem, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);
            obj.TryGetValue("Amount", StringComparison.InvariantCultureIgnoreCase, out var amount);

            //ASSERT
            Assert.Equal(this.expectedAmount, amount);
        }
    }
}