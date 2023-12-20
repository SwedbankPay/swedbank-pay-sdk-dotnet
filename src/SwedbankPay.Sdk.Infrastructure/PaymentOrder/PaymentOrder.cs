using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Aborted;
using SwedbankPay.Sdk.PaymentOrder.Cancelled;
using SwedbankPay.Sdk.PaymentOrder.Failed;
using SwedbankPay.Sdk.PaymentOrder.FailedAttempts;
using SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;
using SwedbankPay.Sdk.PaymentOrder.History;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.Paid;
using SwedbankPay.Sdk.PaymentOrder.PayeeInfo;
using SwedbankPay.Sdk.PaymentOrder.Payer;
using SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;
using SwedbankPay.Sdk.PaymentOrder.Reversed;
using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrder : Identifiable, IPaymentOrder
{
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public Operation Operation { get; }
    public Status Status { get; }
    public Currency? Currency { get; }
    public Amount VatAmount { get; }
    public Amount Amount { get; }
    public string? Description { get; }
    public string? InitiatingSystemUserAgent { get; }
    public Language Language { get; }
    public string[]? AvailableInstruments { get; }
    public string? Implementation { get; }
    public string? Integration { get; }
    public bool InstrumentMode { get; }
    public bool GuestMode { get; }
    public IOrderItemsResponse? OrderItems { get; }
    public IUrlsResponse? Urls { get; }
    public IPayeeInfoResponse? PayeeInfo { get; }
    public IPayerResponse? Payer { get; }
    public IHistoryResponse? History { get; }
    public IFailedResponse? Failed { get; }
    public IAbortedResponse? Aborted { get; }
    public IPaidResponse? Paid { get; }
    public ICancelledResponse? Cancelled { get; }
    public IReversedResponse? Reversed { get; }
    public IFinancialTransactionsResponse? FinancialTransactions { get; }
    public IFailedAttemptsResponse? FailedAttempts { get; }
    public IPostPurchaseFailedAttemptsResponse? PostPurchaseFailedAttempts { get; }
    public Sdk.PaymentOrder.Metadata.Metadata? Metadata { get; }

    internal PaymentOrder(PaymentOrderResponseItemDto paymentOrderResponseItemDto) : base(paymentOrderResponseItemDto.Id)
    {
        Created = paymentOrderResponseItemDto.Created;
        Updated = paymentOrderResponseItemDto.Updated;
        Operation = paymentOrderResponseItemDto.Operation;
        Status= paymentOrderResponseItemDto.Status;
        Currency= paymentOrderResponseItemDto.Currency;
        VatAmount= paymentOrderResponseItemDto.VatAmount;
        Amount= paymentOrderResponseItemDto.Amount;
        Description = paymentOrderResponseItemDto.Description;
        InitiatingSystemUserAgent = paymentOrderResponseItemDto.InitiatingSystemUserAgent;
        Language = new Language(paymentOrderResponseItemDto.Language);
        AvailableInstruments = paymentOrderResponseItemDto.AvailableInstruments;
        Implementation = paymentOrderResponseItemDto.Implementation;
        Integration = paymentOrderResponseItemDto.Integration;
        InstrumentMode = paymentOrderResponseItemDto.InstrumentMode;
        GuestMode = paymentOrderResponseItemDto.GuestMode;
        OrderItems = paymentOrderResponseItemDto.OrderItems?.Map();
        Urls = paymentOrderResponseItemDto.Urls?.Map();
        PayeeInfo = paymentOrderResponseItemDto.PayeeInfo?.Map();
        Payer = paymentOrderResponseItemDto.Payer?.Map();
        History = paymentOrderResponseItemDto.History?.Map();
        Failed = paymentOrderResponseItemDto.Failed?.Map();
        Aborted = paymentOrderResponseItemDto.Aborted?.Map();
        Paid = paymentOrderResponseItemDto.Paid?.Map();
        Cancelled = paymentOrderResponseItemDto.Cancelled?.Map();
        Reversed = paymentOrderResponseItemDto.Reversed?.Map();
        FinancialTransactions = paymentOrderResponseItemDto.FinancialTransactions?.Map();
        FailedAttempts = paymentOrderResponseItemDto.FailedAttempts?.Map();
        PostPurchaseFailedAttempts = paymentOrderResponseItemDto.PostPurchaseFailedAttempts?.Map();
        Metadata = paymentOrderResponseItemDto.Metadata?.Map();
    }
}