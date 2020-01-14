using SwedbankPay.Sdk.PaymentOrders;

using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests
{
    public class IndicatorTests
    {
        [Theory]
        [InlineData(nameof(AccountAgeIndicator.NoAccountGuest), "01")]
        [InlineData(nameof(AccountAgeIndicator.CreatedDuringTransaction), "02")]
        [InlineData(nameof(AccountAgeIndicator.LessThanThirtyDays), "03")]
        [InlineData(nameof(AccountAgeIndicator.ThirtyToSixtyDays), "04")]
        [InlineData(nameof(AccountAgeIndicator.MoreThanSixtyDays), "05")]
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
    }
}