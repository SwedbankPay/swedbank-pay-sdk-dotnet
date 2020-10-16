using System.Text.Json;
using SwedbankPay.Sdk.Common;
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

            var jsonObject = $"{{ \"xX123xxaddress\": {this.expectedAmount} }}";

            //ACT
            var result = JsonSerializer.Deserialize<Amount>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal(this.expectedAmount, result.InLowestMonetaryUnit);
        }


        [Fact]
        public void CanSerialize_Amount()
        {
            //ARRANGE
            var orderItem = new OrderItem("Test", "Test", OrderItemType.Product, "MobilePhone", 3, "pcs", new Amount(2), 0,
                                          new Amount(1), new Amount(2));

            //ACT
            var result = JsonSerializer.Serialize(orderItem, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);
            var amount = obj.RootElement.GetProperty("amount").GetInt64();

            //ASSERT
            Assert.Equal(this.expectedAmount, amount);
        }
    }
}