using System.Text.Json;

using SwedbankPay.Sdk.PaymentOrder.Metadata;

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
        var serialized = JsonSerializer.Serialize(metadata, JsonSerialization.JsonSerialization.Settings);

        var result = JsonSerializer.Deserialize<MetadataDto>(serialized, JsonSerialization.JsonSerialization.Settings);

        Assert.Equal(metadata["key2"], result["key2"]);
        Assert.Equal(metadata["key1"], result["key1"]);
    }
}