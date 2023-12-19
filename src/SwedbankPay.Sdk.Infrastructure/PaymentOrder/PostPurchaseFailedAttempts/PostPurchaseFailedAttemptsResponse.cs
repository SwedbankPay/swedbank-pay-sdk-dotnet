using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.PostPurchaseFailedAttempts;

public record PostPurchaseFailedAttemptsResponse : Identifiable, IPostPurchaseFailedAttemptsResponse
{
    internal PostPurchaseFailedAttemptsResponse(PostPurchaseFailedAttemptsResponseDto dto) : base(dto.Id)
    {
    }
}