using SwedbankPay.Sdk.PaymentOrder.PayeeInfo;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PayeeInfo;

internal record PayeeInfoResponseDto : IdentifiableDto
{
    public string? PayeeId { get; init; }
    public string? PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? MerchantName { get; init; }
    public string? CorporationId { get; init; }
    public string? CorporationName { get; init; }
    public string? SalesChannel { get; init; }
    
    public IPayeeInfoResponse Map()
    {
        return new PayeeInfoResponse(this);
    }
}