using SwedbankPay.Sdk.PaymentOrder.Models;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrder
{
    Uri Id { get; }
    DateTime Created { get; }
    DateTime Updated { get; }
    Operation Operation { get; }
    Status Status { get; }
    Currency? Currency { get; }
    Amount VatAmount { get; }
    Amount Amount { get; }
    string? Description { get; }
    string? InitiatingSystemUserAgent { get; }
    Language Language { get; }
    string[]? AvailableInstruments { get; }
    string? Implementation { get; }
    bool InstrumentMode { get; }
    bool GuestMode { get; }
    OrderItemsResponse? OrderItems { get; } 
    Urls? Urls { get; }
    PayeeInfoResponse? PayeeInfo { get; }
    PayerResponse? Payer { get; }
    HistoryResponse? History { get; }
    FailedResponse? Failed { get; }
    AbortedResponse? Aborted { get; }
    PaidResponse? Paid { get; }
    CancelledResponse? Cancelled { get; }
    ReversedResponse? Reversed { get; }
    FinancialTransactionsResponse? FinancialTransactions { get; }
    FailedAttemptsResponse? FailedAttempts { get; }
    PostPurchaseFailedAttemptsResponse? PostPurchaseFailedAttempts { get; }
    Metadata? Metadata { get; }
}