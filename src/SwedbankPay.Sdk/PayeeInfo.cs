namespace SwedbankPay.Sdk;

public record PayeeInfo(string PayeeReference)
{
    public string? PayeeName { get; init; }
    public string? OrderReference { get; init; }
    public string? PayeeId { get; init; }
    public string PayeeReference { get; } = PayeeReference;
}