namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record PaymentOrderCancelRequestDetailDto
{
    public string Description { get; }
    public string PayeeReference { get; }

    public PaymentOrderCancelRequestDetailDto(PaymentOrderCancelRequestDetail payload)
    {
        Description = payload.Description;
        PayeeReference = payload.PayeeReference;
    }
}