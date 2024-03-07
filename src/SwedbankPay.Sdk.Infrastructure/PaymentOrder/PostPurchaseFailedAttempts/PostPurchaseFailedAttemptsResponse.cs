using SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PostPurchaseFailedAttempts;

internal record PostPurchaseFailedAttemptsResponse : Identifiable, IPostPurchaseFailedAttemptsResponse
{
    internal PostPurchaseFailedAttemptsResponse(PostPurchaseFailedAttemptsResponseDto dto) : base(dto.Id)
    {
    }
}