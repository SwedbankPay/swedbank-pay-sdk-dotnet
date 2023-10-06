namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

public class PaymentOrderReversalRequest
{
    public PaymentOrderReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
    {
        Transaction = new TransactionRequest(amount, vatAmount, description, payeeReference);
    }

    public string ReceiptReference
    {
        set => Transaction.ReceiptReference = value;
    }

    public TransactionRequest Transaction { get; }
}

public class TransactionRequest
{
    public string Description { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
    public string PayeeReference { get; }
    public string ReceiptReference { get; set; }
    public IList<OrderItem> OrderItems { get; }

    public TransactionRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
    {
        Description = description;
        Amount = amount.InLowestMonetaryUnit;
        VatAmount = vatAmount.InLowestMonetaryUnit;
        PayeeReference = payeeReference;
        OrderItems = new List<OrderItem>();
    }

    internal TransactionRequestDto Map()
    {
        return new TransactionRequestDto(this);
    }
}

internal class PaymentOrderReversalRequestDto
{
    public PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
    {
        Transaction = payload.Transaction.Map();
    }

    public TransactionRequestDto Transaction { get; set; }
}

internal class TransactionRequestDto
{
    public string Description { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string PayeeReference { get; set; }
    public string ReceiptReference { get; set; }
    public IList<OrderItemDto> OrderItems { get; set; }

    public TransactionRequestDto(TransactionRequest payload)
    {
        Description = payload.Description;
        Amount = payload.Amount.InLowestMonetaryUnit;
        VatAmount = payload.VatAmount.InLowestMonetaryUnit;
        PayeeReference = payload.PayeeReference;
        ReceiptReference = payload.ReceiptReference;
        OrderItems = payload.OrderItems.Select(x => new OrderItemDto(x)).ToList();
    }
}

internal class PaymentOrderReversalResponseDto
{
    public string Payment { get; set; }
    public PaymentOrderReversalResponseDetailDto Reversal { get; set; }
}

internal class PaymentOrderReversalResponseDetailDto : IdentifiableDto
{
    public TransactionResponseDto Transaction { get; set; }
    
    public PaymentOrderReversalResponseDetailDto(string id) : base(id)
    {
    }
}

public interface IPaymentOrderReversalResponse
{
    Uri Payment { get; }
    PaymentOrderReversalResponseDetail Reversal { get; }
}

public class PaymentOrderReversalResponse : IPaymentOrderReversalResponse
{
    public Uri Payment { get; }
    public PaymentOrderReversalResponseDetail Reversal { get; }
    
    internal PaymentOrderReversalResponse(PaymentOrderReversalResponseDto dto)
    {
        Payment = new Uri(dto.Payment, UriKind.RelativeOrAbsolute);
        Reversal = new PaymentOrderReversalResponseDetail(dto.Reversal);
    }
}

public class PaymentOrderReversalResponseDetail
{
    public TransactionResponse Transaction { get; }

    internal PaymentOrderReversalResponseDetail(PaymentOrderReversalResponseDetailDto dto)
    {
        Transaction = new TransactionResponse(dto.Transaction);
    }
}