using System.Text.Json;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomMetadataConverterTests
    {
        [Fact]
        public void CanSerialize_AndDeserialize_Metadata()
        {
            var metadata = new Metadata
            {
                { "key1", 1000000000000 },
                { "key2", "test-string" }
            };
            var serialized = JsonSerializer.Serialize(metadata, JsonSerialization.JsonSerialization.Settings);

            var result = JsonSerializer.Deserialize<Metadata>(serialized, JsonSerialization.JsonSerialization.Settings);

            Assert.Equal(metadata["key2"], result["key2"]);
            Assert.Equal(metadata["key1"], result["key1"]);
        }
    }
}
