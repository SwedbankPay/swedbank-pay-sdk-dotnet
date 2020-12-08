using SwedbankPay.Sdk.PaymentOrders;
using System;
using Xunit;

namespace SwedbankPay.Sdk.Tests.UnitTests
{
    public class DtoTests
    {
        [Theory]
        [InlineData("te st")]
        [InlineData("sets data")]
        [InlineData("test-data")]
        public void Creating_Abort_WithNotSupportedCharacters_ThrowsException(string data)
        {
            Assert.Throws<ArgumentException>(() => new PaymentOrderAbortRequest(data));
        }

        [Theory]
        [InlineData("testAbortReason")]
        [InlineData("CancelledByConsumer")]
        public void Creating_Abort_WithSupportedCharacters_DoesNotThrowException(string data)
        {
            new PaymentOrderAbortRequest(data);
        }
    }
}
