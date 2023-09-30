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
}

internal class OrderItemResponseDto : IdentifiableDto
{
    public OrderItemResponseDto(string id) : base(id)
    {
    }
}

internal class HistoryResponseDto : IdentifiableDto
{
    public HistoryResponseDto(string id) : base(id)
    {
    }
}

internal class FailedResponseDto : IdentifiableDto
{
    public FailedResponseDto(string id) : base(id)
    {
    }
}

internal class AbortedResponseDto : IdentifiableDto
{
    public AbortedResponseDto(string id) : base(id)
    {
    }
}

internal class PaidResponseDto: IdentifiableDto
{
    public PaidResponseDto(string id) : base(id)
    {
    }
}

internal class CancelledResponseDto: IdentifiableDto
{
    public CancelledResponseDto(string id) : base(id)
    {
    }
}

internal class FinancialTransactionsResponseDto : IdentifiableDto
{
    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }
}

internal class FailedAttemptsResponseDto : IdentifiableDto
{
    public FailedAttemptsResponseDto(string id) : base(id)
    {
    }
}