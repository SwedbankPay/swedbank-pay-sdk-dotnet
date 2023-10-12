using System.Globalization;
using System.Text.Json;

namespace SwedbankPay.Sdk.Tests.Json;

public class CustomDateTimeConverterTests
{
    private class TestDto
    {
        public DateTime TestValue { get; set; }
    }
    
    [Fact]
    public void Converts_DateTime_With_Correct_UTC()
    {
        // Arrange
        var serialized = @"{ ""testValue"": ""2022-04-26T10:00:00.0000000Z"" }";

        // Act
        var result = JsonSerializer.Deserialize<TestDto>(serialized, JsonSerialization.JsonSerialization.Settings)!;

        // Assert
        var expected = DateTime.ParseExact("2022-04-26T10:00:00.0000000Z",
            "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal |
            DateTimeStyles.AdjustToUniversal);
        Assert.NotNull(result);
        Assert.Equal(expected, result.TestValue);
        Assert.Equal(DateTimeKind.Utc, result.TestValue.Kind);
    }
}