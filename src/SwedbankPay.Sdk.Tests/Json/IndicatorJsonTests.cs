using System.Text.Json;

using SwedbankPay.Sdk.PaymentOrders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class IndicatorJsonTests
    {
        [Fact]
        public void CanDeSerialize_AccountAgeIndicator()
        {
            //ARRANGE

            var jsonObject = $"{{ {{ \"AccountAgeIndicator\": \"01\" }} }}";

            //ACT
            var result = JsonSerializer.Deserialize<AccountInfo>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

            //ASSERT
            Assert.Equal("01", result.AccountAgeIndicator.Value);
        }


        [Fact]
        public void CanSerialize_AccountAgeIndicator()
        {
            //ARRANGE
            var accountInfo = new AccountInfo
            {
                AccountAgeIndicator = AccountAgeIndicator.NoAccountGuest
            };

            //ACT
            var result = JsonSerializer.Serialize(accountInfo, JsonSerialization.JsonSerialization.Settings);
            var obj = JsonDocument.Parse(result);

            var accountAgeValue = obj.RootElement.GetProperty("accountAgeIndicator").ToString();

            //ASSERT
            Assert.Equal("01", accountAgeValue);
        }
    }
}