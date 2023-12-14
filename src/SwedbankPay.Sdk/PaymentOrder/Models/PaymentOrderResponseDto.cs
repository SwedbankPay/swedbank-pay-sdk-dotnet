namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; init; } = null!;
    public IList<OperationResponseDto> Operations { get; init; } = new List<OperationResponseDto>();
}