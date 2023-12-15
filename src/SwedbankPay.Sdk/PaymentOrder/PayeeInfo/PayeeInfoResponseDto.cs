namespace SwedbankPay.Sdk.PaymentOrder.PayeeInfo;

internal record PayeeInfoResponseDto : IdentifiableDto
{
    public string? PayeeId { get; init; }
    public string? PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? MerchantName { get; init; }
    public string? CorporationId { get; init; }
    public string? CorporationName { get; init; }
    public string? SalesChannel { get; init; }
    
    public PayeeInfoResponse Map()
    {
        return new PayeeInfoResponse(this);
    }
}