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
        Payer = paymentOrderResponseItemDto.Payer.Map();
        OrderItems = paymentOrderResponseItemDto.OrderItems.Map();
        History = paymentOrderResponseItemDto.History.Map();
        Failed = paymentOrderResponseItemDto.Failed.Map();
        Aborted = paymentOrderResponseItemDto.Aborted.Map();
        Paid = paymentOrderResponseItemDto.Paid.Map();
        Cancelled = paymentOrderResponseItemDto.Cancelled.Map();
        FinancialTransactions = paymentOrderResponseItemDto.FinancialTransactions.Map();
        FailedAttempts = paymentOrderResponseItemDto.FailedAttempts.Map();
        Metadata = paymentOrderResponseItemDto.Metadata.Map();
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
    internal PayerResponse(string id) : base(id)
    {
    }
}

public class OrderItemsResponse : Identifiable
{
    internal OrderItemsResponse(string id) : base(id)
    {
    }
    
    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<OrderItem>? OrderItemList { get; set; }
}

public class HistoryResponse : Identifiable
{
    internal HistoryResponse(string id) : base(id)
    {
    }
}

public class FailedResponse : Identifiable
{
    internal FailedResponse(string id) : base(id)
    {
    }
}

public class AbortedResponse : Identifiable
{
    internal AbortedResponse(string id) : base(id)
    {
    }
}

public class PaidResponse : Identifiable
{
    internal PaidResponse(string id) : base(id)
    {
    }
}

public class CancelledResponse : Identifiable
{
    internal CancelledResponse(string id) : base(id)
    {
    }
}

public class FinancialTransactionsResponse : Identifiable
{
    internal FinancialTransactionsResponse(string id) : base(id)
    {
    }
}

public class FailedAttemptsResponse : Identifiable
{
    internal FailedAttemptsResponse(string id) : base(id)
    {
    }
}

public class MetadataResponse : Identifiable
{
    internal MetadataResponse(string id) : base(id)
    {
    }
}