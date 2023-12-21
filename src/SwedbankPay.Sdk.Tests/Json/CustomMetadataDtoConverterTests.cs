using System.Text.Json;

using SwedbankPay.Sdk.Infrastructure.JsonSerialization;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Metadata;

namespace SwedbankPay.Sdk.Tests.Json;

public class CustomMetadataDtoConverterTests
{
    [Fact]
    public void CanSerialize_AndDeserialize_Metadata()
    {
        var metadata = new MetadataDto
        {
            { "key1", 1000000000000 },
            { "key2", "test-string" }
        };
        var serialized = JsonSerializer.Serialize(metadata, Infrastructure.JsonSerialization.JsonSerialization.Settings);

        var result = JsonSerializer.Deserialize<MetadataDto>(serialized, Infrastructure.JsonSerialization.JsonSerialization.Settings);

        Assert.NotNull(result);
        Assert.Equal(metadata["key2"], result["key2"]);
        Assert.Equal(metadata["key1"], result["key1"]);
    }
}