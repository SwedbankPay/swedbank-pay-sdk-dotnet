using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedbankPay.Sdk.PaymentOrders;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class AccountAgeIndicatorTests
    {
        [Theory]
        [InlineData("No account, guest", "01")]
        [InlineData("Created during transaction", "02")]
        [InlineData("Less than 30 days", "03")]
        [InlineData("30-60 days", "04")]
        [InlineData("More than 60 days", "05")]
        public void FromName_ReturnsAccountAgeIndicatorWithCorrectValue_WhenGivenCorrectName(string name, string value)
        {
            //ACT
            var result = AccountAgeIndicator.FromName(name);

            //ASSERT
            Assert.Equal(value, result.Value);
        }

        [Theory]
        [InlineData(nameof(AccountAgeIndicator.NoAccountGuest), "01")]
        [InlineData(nameof(AccountAgeIndicator.CreatedDuringTransaction), "02")]
        [InlineData(nameof(AccountAgeIndicator.LessThanThirtyDays), "03")]
        [InlineData(nameof(AccountAgeIndicator.ThirtyToSixtyDays), "04")]
        [InlineData(nameof(AccountAgeIndicator.MoreThanSixtyDays), "05")]
        public void FromValue_ReturnsAccountAgeIndicatorWithCorrectName_WhenGivenCorrectValue(string name, string value)
        {
            //ACT
            var result = AccountAgeIndicator.FromValue(value);
            
            
            //ASSERT
            Assert.Equal(name, result.Name);
        }

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