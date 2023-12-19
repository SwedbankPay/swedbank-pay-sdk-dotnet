using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.Urls;

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
    IOrderItemsResponse? OrderItems { get; } 
    IUrlsResponse? Urls { get; }
    IPayeeInfoResponse? PayeeInfo { get; }
    IPayerResponse? Payer { get; }
    IHistoryResponse? History { get; }
    IFailedResponse? Failed { get; }
    IAbortedResponse? Aborted { get; }
    IPaidResponse? Paid { get; }
    ICancelledResponse? Cancelled { get; }
    IReversedResponse? Reversed { get; }
    IFinancialTransactionsResponse? FinancialTransactions { get; }
    IFailedAttemptsResponse? FailedAttempts { get; }
    IPostPurchaseFailedAttemptsResponse? PostPurchaseFailedAttempts { get; }
    Metadata.Metadata? Metadata { get; }
}