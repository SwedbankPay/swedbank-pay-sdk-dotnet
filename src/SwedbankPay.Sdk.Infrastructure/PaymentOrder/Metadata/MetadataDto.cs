using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Metadata;

internal class MetadataDto : Dictionary<string, object?>
{
    [JsonConstructor]
    public MetadataDto()
    {
    }

    internal MetadataDto(IDictionary<string, object?> dictionary) : base(dictionary)
    {
    }

    public string? Id { get; set; }

    internal Sdk.PaymentOrder.Metadata.Metadata Map()
    {
        return new Sdk.PaymentOrder.Metadata.Metadata(this);
    }
}