namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; set; } = null!;
    public IList<OperationResponseDto> Operations { get; set; } = new List<OperationResponseDto>();
}