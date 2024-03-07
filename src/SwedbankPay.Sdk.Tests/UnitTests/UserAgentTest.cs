namespace SwedbankPay.Sdk.Tests.UnitTests;

public class UserAgentTest
{
#if RELEASE
        [Fact]
        public void DefaultUserAgent_ReturnsNotDefaultVersion()
        {
            //ACT
            Assert.StartsWith("swedbankpay-sdk-dotnet/", UserAgent.Default);
            Assert.NotEqual("swedbankpay-sdk-dotnet/1.0.0.0", UserAgent.Default);
        }
#endif
}