using System.Text.Json;

using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;

namespace SwedbankPay.Sdk.Tests.UnitTests;

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

    [Fact]
    public void DateTime_IsCreated_WithCorrectType()
    {
        var testData = DateTime.Parse("2020-04-07T12:10:36.212828Z");
        var serialized = JsonSerializer.Serialize(testData, Infrastructure.JsonSerialization.JsonSerialization.Settings);
        var result = JsonSerializer.Deserialize<DateTime>(serialized, Infrastructure.JsonSerialization.JsonSerialization.Settings);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }
}