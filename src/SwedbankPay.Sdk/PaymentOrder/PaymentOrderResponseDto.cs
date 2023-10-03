namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; set; }
    public IList<OperationResponseDto> Operations { get; set; }
}

internal class PaymentOrderResponseItemDto
{
    public string Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Operation { get; set; }
    public string Status { get; set; }
    public string Currency { get; set; }
    public long VatAmount { get; set; }
    public long Amount { get; set; }
    public string Description { get; set; }
    public string InitiatingSystemUserAgent { get; set; }
    public string Language { get; set; }
    public string[] AvailableInstruments { get; set; }
    public string Implementation { get; set; }
    public bool InstrumentMode { get; set; }
    public bool GuestMode { get; set; }
    public PayerResponseDto Payer { get; set; }
    public OrderItemResponseDto OrderItems { get; set; }
    public HistoryResponseDto History { get; set; }
    public FailedResponseDto Failed { get; set; }
    public AbortedResponseDto Aborted { get; set; }
    public PaidResponseDto Paid { get; set; }
    public CancelledResponseDto Cancelled { get; set; }
    public FinancialTransactionsResponseDto FinancialTransactions { get; set; }
    public FailedAttemptsResponseDto FailedAttempts { get; set; }
    public MetadataResponseDto Metadata { get; set; }
}

internal class PayerResponseDto : IdentifiableDto
{
    public PayerResponseDto(string id) : base(id)
    {
    }

    public PayerResponse Map()
    {
        return new PayerResponse(Id);
    }
}

internal class OrderItemResponseDto : IdentifiableDto
{
    public OrderItemResponseDto(string id) : base(id)
    {
    }

    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<OrderItemDto>? OrderItemList { get; set; }

    internal OrderItemsResponse Map()
    {
        var orderItemList = OrderItemList?.Select(item => item.Map()).ToList();
        return new OrderItemsResponse(Id)
        {
            OrderItemList = orderItemList
        };
    }
}

internal class HistoryResponseDto : IdentifiableDto
{
    public HistoryResponseDto(string id) : base(id)
    {
    }

    public HistoryResponse Map()
    {
        return new HistoryResponse(Id);
    }
}

internal class FailedResponseDto : IdentifiableDto
{
    public FailedResponseDto(string id) : base(id)
    {
    }

    public FailedResponse Map()
    {
        return new FailedResponse(Id);
    }
}

internal class AbortedResponseDto : IdentifiableDto
{
    public AbortedResponseDto(string id) : base(id)
    {
    }

    public AbortedResponse Map()
    {
        return new AbortedResponse(Id);
    }
}

internal class PaidResponseDto : IdentifiableDto
{
    public PaidResponseDto(string id) : base(id)
    {
    }

    public PaidResponse Map()
    {
        return new PaidResponse(Id);
    }
}

internal class CancelledResponseDto : IdentifiableDto
{
    public CancelledResponseDto(string id) : base(id)
    {
    }

    public CancelledResponse Map()
    {
        return new CancelledResponse(Id);
    }
}

internal class FinancialTransactionsResponseDto : IdentifiableDto
{
    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }

    public FinancialTransactionsResponse Map()
    {
        return new FinancialTransactionsResponse(Id);
    }
}

internal class FailedAttemptsResponseDto : IdentifiableDto
{
    public FailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public FailedAttemptsResponse Map()
    {
        return new FailedAttemptsResponse(Id);
    }
}