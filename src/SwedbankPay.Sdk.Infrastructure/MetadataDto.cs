using System.Collections.Generic;

namespace SwedbankPay.Sdk;

internal class MetadataDto : Dictionary<string, object>
{
    public MetadataDto()
    {
    }

    public MetadataDto(IDictionary<string, object> dictionary) : base(dictionary)
    {
    }

    public string Id { get; set; }

    internal Metadata Map()
    {
        var metaData = new Metadata(this);
        return metaData;
    }
}
