namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

/// <summary>
/// API request object for capturing funds for a payment order.
/// </summary>
public class PaymentOrderCaptureRequest
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCaptureRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="receiptReference"></param>
    public PaymentOrderCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference,
        string receiptReference)
    {
        Transaction =
            new PaymentOrderCaptureTransaction(amount, vatAmount, description, payeeReference, receiptReference);
    }

    /// <summary>
    /// Transactional details about the capture of the current payment order.
    /// </summary>
    public PaymentOrderCaptureTransaction Transaction { get; }
}

/// <summary>
/// Transactional details for capturing funds for a payment order.
/// </summary>
public class PaymentOrderCaptureTransaction
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCaptureTransaction"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="receiptReference"></param>
    protected internal PaymentOrderCaptureTransaction(Amount amount,
        Amount vatAmount,
        string description,
        string payeeReference,
        string receiptReference)
    {
        Amount = amount;
        VatAmount = vatAmount;
        Description = description;
        PayeeReference = payeeReference;
        ReceiptReference = receiptReference;
    }

    public string ReceiptReference { get; set; }

    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> (including VAT, if any) to charge the payer
    /// , entered in the lowest monetary unit of the selected currency. 
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// A human readable description of maximum 40 characters of the transaction.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The array of items being purchased with the order.
    /// Used to print on invoices if the payer chooses to pay with invoice, among other things.
    /// It should only contain the items to be captured from the order.
    /// </summary>
    public IList<OrderItem> OrderItems { get; } = new List<OrderItem>();

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation. 
    /// </summary>
    public string PayeeReference { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much ofthe total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    public Amount VatAmount { get; }
}

internal class PaymentOrderCaptureRequestDto
{
    public PaymentOrderCaptureTransactionDto Transaction { get; set; }

    public PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
    {
        Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
    }
}

internal class PaymentOrderCaptureTransactionDto
{
    public PaymentOrderCaptureTransactionDto(PaymentOrderCaptureTransaction payload)
    {
        Description = payload.Description;
        Amount = payload.Amount.InLowestMonetaryUnit;
        VatAmount = payload.VatAmount.InLowestMonetaryUnit;
        PayeeReference = payload.PayeeReference;
        ReceiptReference = payload.ReceiptReference;
        OrderItems = payload.OrderItems.Select(x => new OrderItemDto(x)).ToList();
    }

    public string? Description { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }
    public IList<OrderItemDto>? OrderItems { get; set; }
}

internal record PaymentOrderCaptureResponseDto
{
    public string Payment { get; set; } = null!;

    public PaymentOrderCaptureResponseDetailDto? Capture { get; set; }
}

internal record PaymentOrderCaptureResponseDetailDto : IdentifiableDto
{
    public TransactionResponseDto? Transaction { get; set; }

    public PaymentOrderCaptureResponseDetailDto(string id) : base(id)
    {
    }

    public PaymentOrderCaptureResponseDetail Map()
    {
        return new PaymentOrderCaptureResponseDetail(this);
    }
}

public interface IPaymentOrderCaptureResponse
{
    Uri Payment { get; }
    PaymentOrderCaptureResponseDetail? Capture { get; }
}

public class PaymentOrderCaptureResponse : IPaymentOrderCaptureResponse
{
    public Uri Payment { get; }

    public PaymentOrderCaptureResponseDetail? Capture { get; }

    internal PaymentOrderCaptureResponse(PaymentOrderCaptureResponseDto dto)
    {
        Payment = new Uri(dto.Payment, UriKind.RelativeOrAbsolute);
        Capture = dto.Capture?.Map();
    }
}

public class PaymentOrderCaptureResponseDetail
{
    public TransactionResponse? Transaction { get; }

    internal PaymentOrderCaptureResponseDetail(PaymentOrderCaptureResponseDetailDto dto)
    {
        Transaction = dto.Transaction?.Map();
    }
}

internal record TransactionResponseDto : IdentifiableDto
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Type { get; set; } = null!;
    public string State { get; set; } = null!;
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }

    public TransactionResponseDto(string id) : base(id)
    {
    }

    public TransactionResponse Map()
    {
        return new TransactionResponse(this);
    }
}

public class TransactionResponse : Identifiable
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Type { get; set; }
    public State State { get; set; }
    public Amount Amount { get; set; }
    public Amount VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }

    internal TransactionResponse(TransactionResponseDto dto) : base(dto.Id)
    {
        Created = dto.Created;
        Updated = dto.Updated;
        Type = dto.Type;
        State = dto.State;
        Amount = new Amount(dto.Amount);
        VatAmount = new Amount(dto.VatAmount);
        Description = dto.Description;
        PayeeReference = dto.PayeeReference;
        ReceiptReference = dto.ReceiptReference;
    }
}