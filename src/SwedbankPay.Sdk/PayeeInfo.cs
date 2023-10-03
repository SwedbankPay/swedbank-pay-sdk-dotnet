namespace SwedbankPay.Sdk;

public record PayeeInfo(string PayeeId, string PayeeReference)
{
    public string? PayeeName { get; set; }
    public string? OrderReference { get; set; }
    public string PayeeId { get; } = PayeeId;
    public string PayeeReference { get; } = PayeeReference;
}