namespace SwedbankPay.Sdk.PaymentOrder.PayeeInfo;

public interface IPayeeInfoResponse
{
    public string? PayeeId { get; }
    public string? PayeeReference { get; }
    public string? PayeeName { get; }
    public string? MerchantName { get; }
    public string? CorporationId { get; }
    public string? CorporationName { get; }
    public string? SalesChannel { get; }
}