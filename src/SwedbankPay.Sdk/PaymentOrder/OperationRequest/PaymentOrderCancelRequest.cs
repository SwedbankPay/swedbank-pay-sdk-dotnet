namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public class PaymentOrderCancelRequest
{
    public PaymentOrderCancelRequestDetail Transaction { get; }

    public PaymentOrderCancelRequest(string description, string payeeReference)
    {
        Transaction = new PaymentOrderCancelRequestDetail(description, payeeReference);
    }
}

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

internal record PaymentOrderCancelRequestDto
{
    public PaymentOrderCancelRequestDetailDto Transaction { get; }

    public PaymentOrderCancelRequestDto(PaymentOrderCancelRequest payload)
    {
        Transaction = new PaymentOrderCancelRequestDetailDto(payload.Transaction);
    }
}

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