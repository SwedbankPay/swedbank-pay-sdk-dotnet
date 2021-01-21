using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
