using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests
{
    public class AmountTests
    {
        [Fact]
        public void Amount_SupportsLargeAmount_WithoutException()
        {
            _ = new Amount(9999999900);
        }

        [Fact]
        public void Amount_CorrectlyStoresRightAmount_WithoutException()
        {
            var amount = new Amount(662.50M);
            Assert.Equal(66250, amount.InLowestMonetaryUnit);
        }
    }
}
