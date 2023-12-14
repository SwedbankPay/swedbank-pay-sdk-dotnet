namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public class PaymentOrderCancelRequestDetail
{
    public string Description { get; }
    public string PayeeReference { get; }

    public PaymentOrderCancelRequestDetail(string description, string payeeReference)
    {
        Description = description;
        PayeeReference = payeeReference;
    }
}