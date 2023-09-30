namespace SwedbankPay.Sdk;

internal class PayeeInfoDto
{
    public PayeeInfoDto(PayeeInfo payeeInfo)
    {
        PayeeId = payeeInfo.PayeeId;
        PayeeReference = payeeInfo.PayeeReference;
        PayeeName = payeeInfo.PayeeName;
        OrderReference = payeeInfo.OrderReference;
    }

    public string PayeeId { get; set; }
    public string PayeeReference { get; set; }
    public string? PayeeName { get; set; }
    public string? OrderReference { get; set; }
}