namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaymentOrderResponseItemDto
{
    public string Id { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string? Operation { get; set; }
    public string Status { get; set; } = null!;
    public string Currency { get; set; } = null!;
    public long VatAmount { get; set; }
    public long Amount { get; set; }
    public string? Description { get; set; }
    public string? InitiatingSystemUserAgent { get; set; }
    public string Language { get; set; } = null!;
    public string[]? AvailableInstruments { get; set; }
    public string? Implementation { get; set; }
    public string? Integration { get; set; }
    public bool InstrumentMode { get; set; }
    public bool GuestMode { get; set; }
    public PayerResponseDto? Payer { get; set; }
    public OrderItemResponseDto? OrderItems { get; set; }
    public UrlsDto? Urls { get; set; }
    public IdentifiableDto? PayeeInfo { get; set; }
    public IdentifiableDto? Payers { get; set; }
    public HistoryResponseDto? History { get; set; }
    public FailedResponseDto? Failed { get; set; }
    public AbortedResponseDto? Aborted { get; set; }
    public PaidResponseDto? Paid { get; set; }
    public CancelledResponseDto? Cancelled { get; set; }
    public ReversedResponseDto? Reversed { get; set; }
    public FinancialTransactionsResponseDto? FinancialTransactions { get; set; }
    public FailedAttemptsResponseDto? FailedAttempts { get; set; }
    public PostPurchaseFailedAttemptsResponseDto? PostPurchaseFailedAttempts { get; set; }
    public MetadataDto? Metadata { get; set; }
}