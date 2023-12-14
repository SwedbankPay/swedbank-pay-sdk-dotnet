namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class PostPurchaseFailedAttemptsResponse : Identifiable
{
    internal PostPurchaseFailedAttemptsResponse(PostPurchaseFailedAttemptsResponseDto dto) : base(dto.Id)
    {
    }
}