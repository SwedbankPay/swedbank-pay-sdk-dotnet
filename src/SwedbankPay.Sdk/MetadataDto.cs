using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk;

internal class MetadataDto : Dictionary<string, object>
{
    [JsonConstructor]
    public MetadataDto()
    {
    }

    internal MetadataDto(IDictionary<string, object> dictionary) : base(dictionary)
    {
    }

    public string Id { get; set; }

    internal Metadata Map()
    {
        return new Metadata(this);
    }
}