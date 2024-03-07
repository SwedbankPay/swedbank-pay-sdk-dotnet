using SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PostPurchaseFailedAttempts;

internal record PostPurchaseFailedAttemptsResponseDto : IdentifiableDto
{
    public PostPurchaseFailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public IPostPurchaseFailedAttemptsResponse Map()
    {
        return new PostPurchaseFailedAttemptsResponse(this);
    }
}