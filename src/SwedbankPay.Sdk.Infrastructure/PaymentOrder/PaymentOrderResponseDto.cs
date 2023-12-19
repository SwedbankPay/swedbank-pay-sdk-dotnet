using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; init; } = null!;
    public OperationListDto Operations { get; init; } = null!;
    
    public IPaymentOrderResponse Map(HttpClient httpClient)
    {
        return new PaymentOrderResponse(this, httpClient);
    }
}