namespace SwedbankPay.Sdk;

internal record PayeeInfoDto
{
    public PayeeInfoDto(PayeeInfo payeeInfo)
    {
        PayeeId = payeeInfo.PayeeId;
        PayeeReference = payeeInfo.PayeeReference;
        PayeeName = payeeInfo.PayeeName;
        OrderReference = payeeInfo.OrderReference;
    }

    public string PayeeId { get; init; }
    public string PayeeReference { get; init; }
    public string? PayeeName { get; init; }
    public string? OrderReference { get; init; }
}