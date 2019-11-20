namespace SwedbankPay.Sdk.Tests.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SwedbankPay.Sdk.PaymentOrders;
    using Xunit;

    public class IndicatorJsonTests
    {
        [Fact]
        public void CanDeSerialize_AccountAgeIndicator()
        {
            //ARRANGE

            var jsonObject = new JObject();
            jsonObject.Add("AccountAgeIndicator", "01");

            //ACT
            var result = JsonConvert.DeserializeObject<AccountInfo>(jsonObject.ToString());

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
            var result = JsonConvert.SerializeObject(accountInfo);
            var obj = JObject.Parse(result);

            var accountAgeValue = obj.GetValue(nameof(AccountAgeIndicator)).ToString();

            //ASSERT
            Assert.Equal("01", accountAgeValue);
        }
    }
}