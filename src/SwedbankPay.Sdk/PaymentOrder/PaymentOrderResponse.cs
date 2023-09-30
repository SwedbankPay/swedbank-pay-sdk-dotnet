namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrderResponse
{
    /// <summary>
    /// Currently available operations of this payment order.
    /// </summary>
    IPaymentOrderOperations Operations { get; }

    /// <summary>
    /// The current payment order.
    /// </summary>
    IPaymentOrder PaymentOrder { get; }
}

public class PaymentOrderResponse: IPaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);
        
        var httpOperations = new OperationList();
        foreach (var item in paymentOrderResponseDto.Operations)
        {
            var rel = new LinkRelation(item.Rel);
            var href = new Uri(item.Href, UriKind.RelativeOrAbsolute);
            httpOperations.Add(new HttpOperation(href, rel, item.Method, item.ContentType));
        }

        Operations = new PaymentOrderOperations(httpOperations, httpClient);
    }

    public IPaymentOrder PaymentOrder { get; }
    public IPaymentOrderOperations Operations { get; }
}


public interface IPaymentOrder
{
    string Id { get; }
    DateTime Created { get; }
    DateTime Updated { get; }
    string Operation { get; }
    string Status { get; }
    string Currency { get; }
    Amount VatAmount { get; }
    Amount Amount { get; }
    string Description { get; }
    string InitiatingSystemUserAgent { get; }
    Language Language { get; }
    string[] AvailableInstruments { get; }
    string Implementation { get; }
    bool InstrumentMode { get; }
    bool GuestMode { get; }
    PayerResponse Payer { get; }
    OrderItemsResponse OrderItems { get; }
    HistoryResponse History { get; }
    FailedResponse Failed { get; }
    AbortedResponse Aborted { get; }
    PaidResponse Paid { get; }
    CancelledResponse Cancelled { get; }
    FinancialTransactionsResponse FinancialTransactions { get; }
    FailedAttemptsResponse FailedAttempts { get; }
    MetadataResponse Metadata { get; }
}

public class PaymentOrder : IPaymentOrder
{
    internal PaymentOrder(PaymentOrderResponseItemDto paymentOrderResponseItemDto)
    {
        Id = paymentOrderResponseItemDto.Id;
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
        InstrumentMode = paymentOrderResponseItemDto.InstrumentMode;
        GuestMode = paymentOrderResponseItemDto.GuestMode;
        Payer = new PayerResponse(paymentOrderResponseItemDto.Payer);
        OrderItems = new OrderItemsResponse(paymentOrderResponseItemDto.OrderItems);
        History = new HistoryResponse(paymentOrderResponseItemDto.History);
        Failed = new FailedResponse(paymentOrderResponseItemDto.Failed);
        Aborted = new AbortedResponse(paymentOrderResponseItemDto.Aborted);
        Paid = new PaidResponse(paymentOrderResponseItemDto.Paid);
        Cancelled = new CancelledResponse(paymentOrderResponseItemDto.Cancelled);
        FinancialTransactions = new FinancialTransactionsResponse(paymentOrderResponseItemDto.FinancialTransactions);
        FailedAttempts = new FailedAttemptsResponse(paymentOrderResponseItemDto.FailedAttempts);
        Metadata = new MetadataResponse(paymentOrderResponseItemDto.Metadata);
    }

    public string Id { get; }
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public string Operation { get; }
    public string Status { get; }
    public string Currency { get; }
    public Amount VatAmount { get; }
    public Amount Amount { get; }
    public string Description { get; }
    public string InitiatingSystemUserAgent { get; }
    public Language Language { get; }
    public string[] AvailableInstruments { get; }
    public string Implementation { get; }
    public bool InstrumentMode { get; }
    public bool GuestMode { get; }
    public PayerResponse Payer { get; }
    public OrderItemsResponse OrderItems { get; }
    public HistoryResponse History { get; }
    public FailedResponse Failed { get; }
    public AbortedResponse Aborted { get; }
    public PaidResponse Paid { get; }
    public CancelledResponse Cancelled { get; }
    public FinancialTransactionsResponse FinancialTransactions { get; }
    public FailedAttemptsResponse FailedAttempts { get; }
    public MetadataResponse Metadata { get; }
}

public class PayerResponse : Identifiable
{
    internal PayerResponse(PayerResponseDto payer) : base(payer.Id)
    {
    }
}

public class OrderItemsResponse : Identifiable
{
    internal OrderItemsResponse(OrderItemResponseDto orderItems) : base(orderItems.Id)
    {
    }
}

public class HistoryResponse : Identifiable
{
    internal HistoryResponse(HistoryResponseDto historyResponse) : base(historyResponse.Id)
    {
    }
}

public class FailedResponse : Identifiable
{
    internal FailedResponse(FailedResponseDto failedResponse) : base(failedResponse.Id)
    {
    }
}

public class AbortedResponse : Identifiable
{
    internal AbortedResponse(AbortedResponseDto abortedResponse) : base(abortedResponse.Id)
    {
    }
}

public class PaidResponse : Identifiable
{
    internal PaidResponse(PaidResponseDto paidResponse) : base(paidResponse.Id)
    {
    }
}

public class CancelledResponse : Identifiable
{
    internal CancelledResponse(CancelledResponseDto cancelledResponse) : base(cancelledResponse.Id)
    {
    }
}

public class FinancialTransactionsResponse : Identifiable
{
    internal FinancialTransactionsResponse(FinancialTransactionsResponseDto financialTransactionsResponse) : base(financialTransactionsResponse.Id)
    {
    }
}

public class FailedAttemptsResponse : Identifiable
{
    internal FailedAttemptsResponse(FailedAttemptsResponseDto failedAttemptsResponse) : base(failedAttemptsResponse.Id)
    {
    }
}

public class MetadataResponse : Identifiable
{
    internal MetadataResponse(MetadataResponseDto metadataResponse) : base(metadataResponse.Id)
    {
    }
}