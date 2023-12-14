namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public record PaymentOrderCancelRequest
{
    public PaymentOrderCancelRequestDetail Transaction { get; }

    public PaymentOrderCancelRequest(string description, string payeeReference)
    {
        Transaction = new PaymentOrderCancelRequestDetail(description, payeeReference);
    }
}