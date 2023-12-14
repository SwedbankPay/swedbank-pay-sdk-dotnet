namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record AbortedResponseDto : IdentifiableDto
{
    public string? AbortReason { get; set; }

    public AbortedResponseDto(string id) : base(id)
    {
    }

    public AbortedResponse Map()
    {
        return new AbortedResponse(this);
    }
}