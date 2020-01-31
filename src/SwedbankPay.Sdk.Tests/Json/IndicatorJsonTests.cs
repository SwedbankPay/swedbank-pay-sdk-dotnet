using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var jsonObject = new JObject
            {
                { "AccountAgeIndicator", "01" }
            };

            //ACT
            var result = JsonConvert.DeserializeObject<AccountInfo>(jsonObject.ToString(), JsonSerialization.JsonSerialization.Settings);

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
            var result = JsonConvert.SerializeObject(accountInfo, JsonSerialization.JsonSerialization.Settings);
            var obj = JObject.Parse(result);

            var accountAgeValue = obj.GetValue("accountAgeIndicator");

            //ASSERT
            Assert.Equal("01", accountAgeValue);
        }
    }
}