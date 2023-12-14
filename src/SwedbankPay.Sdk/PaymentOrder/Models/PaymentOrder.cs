namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record PaymentOrder : Identifiable, IPaymentOrder
{
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public string? Operation { get; }
    public Status Status { get; }
    public string? Currency { get; }
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
    public OrderItemsResponse? OrderItems { get; }
    public Urls? Urls { get; }
    public Identifiable? PayeeInfo { get; }
    public PayerResponse? Payer { get; }
    public HistoryResponse? History { get; }
    public FailedResponse? Failed { get; }
    public AbortedResponse? Aborted { get; }
    public PaidResponse? Paid { get; }
    public CancelledResponse? Cancelled { get; }
    public ReversedResponse? Reversed { get; }
    public FinancialTransactionsResponse? FinancialTransactions { get; }
    public FailedAttemptsResponse? FailedAttempts { get; }
    public PostPurchaseFailedAttemptsResponse? PostPurchaseFailedAttempts { get; }
    public Metadata? Metadata { get; }

    internal PaymentOrder(PaymentOrderResponseItemDto paymentOrderResponseItemDto) : base(paymentOrderResponseItemDto.Id)
    {
        Created = paymentOrderResponseItemDto.Created;
        Updated = paymentOrderResponseItemDto.Updated;
        Operation = paymentOrderResponseItemDto.Operation;
        Status = paymentOrderResponseItemDto.Status;
        Currency = paymentOrderResponseItemDto.Currency;
        VatAmount = new Amount(paymentOrderResponseItemDto.VatAmount);
        Amount = new Amount(paymentOrderResponseItemDto.Amount);
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
        PayeeInfo = paymentOrderResponseItemDto.PayeeInfo != null ? new Identifiable(paymentOrderResponseItemDto.PayeeInfo.Id) : null;
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