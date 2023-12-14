namespace SwedbankPay.Sdk;

public record PayeeInfo(string PayeeId, string PayeeReference)
{
    public string? PayeeName { get; init; }
    public string? OrderReference { get; init; }
    public string PayeeId { get; } = PayeeId;
    public string PayeeReference { get; } = PayeeReference;
}