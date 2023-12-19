using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PayeeInfo;

public record PayeeInfoResponse : Identifiable, IPayeeInfoResponse
{
    public string? PayeeId { get; init; }
    public string? PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? MerchantName { get; init; }
    public string? CorporationId { get; init; }
    public string? CorporationName { get; init; }
    public string? SalesChannel { get; init; }
    
    internal PayeeInfoResponse(PayeeInfoResponseDto dto) : base(dto.Id)
    {
        PayeeId = dto.PayeeId;
        PayeeReference = dto.PayeeReference;
        PayeeName = dto.PayeeName;
        MerchantName = dto.MerchantName;
        CorporationId = dto.CorporationId;
        CorporationName = dto.CorporationName;
        SalesChannel = dto.SalesChannel;
    }
}