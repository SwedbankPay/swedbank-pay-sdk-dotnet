using SwedbankPay.Sdk.PaymentOrder.Aborted;
using SwedbankPay.Sdk.PaymentOrder.Cancelled;
using SwedbankPay.Sdk.PaymentOrder.Failed;
using SwedbankPay.Sdk.PaymentOrder.FailedAttempts;
using SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;
using SwedbankPay.Sdk.PaymentOrder.History;
using SwedbankPay.Sdk.PaymentOrder.Metadata;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.Paid;
using SwedbankPay.Sdk.PaymentOrder.PayeeInfo;
using SwedbankPay.Sdk.PaymentOrder.Payer;
using SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;
using SwedbankPay.Sdk.PaymentOrder.Reversed;

namespace SwedbankPay.Sdk.PaymentOrder;

internal record PaymentOrderResponseItemDto
{
    public string Id { get; init; } = null!;
    public DateTime Created { get; init; }
    public DateTime Updated { get; init; }
    public string Operation { get; init; } = null!;
    public string Status { get; init; } = null!;
    public string Currency { get; init; } = null!;
    public long VatAmount { get; init; }
    public long Amount { get; init; }
    public string? Description { get; init; }
    public string? InitiatingSystemUserAgent { get; init; }
    public string Language { get; init; } = null!;
    public string[]? AvailableInstruments { get; init; }
    public string? Implementation { get; init; }
    public string? Integration { get; init; }
    public bool InstrumentMode { get; init; }
    public bool GuestMode { get; init; }
    public PayerResponseDto? Payer { get; init; }
    public OrderItemResponseDto? OrderItems { get; init; }
    public UrlsDto? Urls { get; init; }
    public PayeeInfoResponseDto? PayeeInfo { get; init; }
    public HistoryResponseDto? History { get; init; }
    public FailedResponseDto? Failed { get; init; }
    public AbortedResponseDto? Aborted { get; init; }
    public PaidResponseDto? Paid { get; init; }
    public CancelledResponseDto? Cancelled { get; init; }
    public ReversedResponseDto? Reversed { get; init; }
    public FinancialTransactionsResponseDto? FinancialTransactions { get; init; }
    public FailedAttemptsResponseDto? FailedAttempts { get; init; }
    public PostPurchaseFailedAttemptsResponseDto? PostPurchaseFailedAttempts { get; init; }
    public MetadataDto? Metadata { get; init; }
}