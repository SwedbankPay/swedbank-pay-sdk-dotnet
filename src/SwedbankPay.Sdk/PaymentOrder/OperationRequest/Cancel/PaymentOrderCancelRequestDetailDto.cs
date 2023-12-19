namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Cancel;

internal record PaymentOrderCancelRequestDetailDto
{
    public string Description { get; }
    public string PayeeReference { get; }

    internal PaymentOrderCancelRequestDetailDto(PaymentOrderCancelRequestDetail payload)
    {
        Description = payload.Description;
        PayeeReference = payload.PayeeReference;
    }
}