using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk;

internal class MetadataResponseDto : IdentifiableDto
{
    public MetadataResponseDto(string id) : base(id)
    {
    }

    public MetadataResponse Map()
    {
        return new MetadataResponse(Id);
    }
}