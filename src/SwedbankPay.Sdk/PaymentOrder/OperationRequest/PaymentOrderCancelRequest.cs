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

internal class PaymentOrderCancelRequestDto
{
    public PaymentOrderCancelRequestDetailDto Transaction { get; set; }

    public PaymentOrderCancelRequestDto(PaymentOrderCancelRequest payload)
    {
        Transaction = new PaymentOrderCancelRequestDetailDto(payload.Transaction);
    }
}

internal class PaymentOrderCancelRequestDetailDto
{
    public string Description { get; }
    public string PayeeReference { get; }

    public PaymentOrderCancelRequestDetailDto(PaymentOrderCancelRequestDetail payload)
    {
        Description = payload.Description;
        PayeeReference = payload.PayeeReference;
    }
}

internal class PaymentOrderCancelResponseDto
{
    public string Payment { get; set; }

    public PaymentOrderCancelResponseDetailDto Cancellation { get; set; }
}

internal class PaymentOrderCancelResponseDetailDto : IdentifiableDto
{
    public TransactionResponseDto Transaction { get; set; }

    public PaymentOrderCancelResponseDetailDto(string id) : base(id)
    {
    }

    public PaymentOrderCancelResponseDetail Map()
    {
       return new PaymentOrderCancelResponseDetail(this);
    }
}

public interface IPaymentOrderCancelResponse
{
    Uri Payment { get; }
    PaymentOrderCancelResponseDetail Cancellation { get; }
}

public class PaymentOrderCancelResponse : IPaymentOrderCancelResponse
{
    public Uri Payment { get; }
    public PaymentOrderCancelResponseDetail Cancellation { get; }

    internal PaymentOrderCancelResponse(PaymentOrderCancelResponseDto dto)
    {
        Payment = new Uri(dto.Payment, UriKind.RelativeOrAbsolute);
        Cancellation = dto.Cancellation.Map();
    }
}

public class PaymentOrderCancelResponseDetail
{
    internal PaymentOrderCancelResponseDetail(PaymentOrderCancelResponseDetailDto dto)
    {
        Transaction = dto.Transaction.Map();
    }

    public TransactionResponse Transaction { get; }
}