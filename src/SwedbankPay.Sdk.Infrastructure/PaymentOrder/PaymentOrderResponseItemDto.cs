using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Aborted;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Failed;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.FailedAttempts;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.FinancialTransactions;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.History;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Metadata;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Paid;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.PayeeInfo;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.PostPurchaseFailedAttempts;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrderResponseItemDto
{
    public string Id { get; init; } = null!;
    public DateTime Created { get; init; }
    public DateTime Updated { get; init; }
    public string Operation { get; init; } = null!;
    public string Status { get; init; } = null!;
    public string Currency { get; init; } = null!;
    public long Amount { get; init; }
    public long VatAmount { get; init; }
    public long RemainingCaptureAmount { get; init; }
    public long RemainingReversalAmount { get; init; }
    public long RemainingCancellationAmount { get; init; }
    public string? Description { get; init; }
    public string? InitiatingSystemUserAgent { get; init; }
    public string Language { get; init; } = null!;
    public string[]? AvailableInstruments { get; init; }
    public string? Implementation { get; init; }
    public string? Integration { get; init; }
    public bool InstrumentMode { get; init; }
    public bool GuestMode { get; init; }
    public PayerResponseDto? Payer { get; init; }
    public OrderItemsResponseDto? OrderItems { get; init; }
    public UrlsResponseDto? Urls { get; init; }
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