namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record PostPurchaseFailedAttemptsResponse : Identifiable
{
    internal PostPurchaseFailedAttemptsResponse(PostPurchaseFailedAttemptsResponseDto dto) : base(dto.Id)
    {
    }
}