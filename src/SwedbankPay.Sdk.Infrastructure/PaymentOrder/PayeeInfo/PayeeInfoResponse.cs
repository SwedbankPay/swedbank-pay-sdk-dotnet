using SwedbankPay.Sdk.PaymentOrder.PayeeInfo;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PayeeInfo;

internal record PayeeInfoResponse : Identifiable, IPayeeInfoResponse
{
    public string? PayeeId { get; init; }
    public string? PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? MerchantName { get; init; }
    public string? CorporationId { get; init; }
    public string? CorporationName { get; init; }
    public string? SalesChannel { get; init; }
    public string? Subsite { get; init; }
    public string? SiteId { get; init; }
    
    internal PayeeInfoResponse(PayeeInfoResponseDto dto) : base(dto.Id)
    {
        PayeeId = dto.PayeeId;
        PayeeReference = dto.PayeeReference;
        PayeeName = dto.PayeeName;
        MerchantName = dto.MerchantName;
        CorporationId = dto.CorporationId;
        CorporationName = dto.CorporationName;
        SalesChannel = dto.SalesChannel;
        Subsite = dto.Subsite;
        SiteId = dto.SiteId;
    }
}