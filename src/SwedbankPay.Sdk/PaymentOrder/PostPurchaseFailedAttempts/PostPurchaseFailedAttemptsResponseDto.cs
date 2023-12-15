namespace SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;

internal record PostPurchaseFailedAttemptsResponseDto : IdentifiableDto
{
    public PostPurchaseFailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public PostPurchaseFailedAttemptsResponse Map()
    {
        return new PostPurchaseFailedAttemptsResponse(this);
    }
}