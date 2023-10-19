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

public class PaymentOrderResponse : IPaymentOrderResponse
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
    Uri Id { get; }
    DateTime Created { get; }
    DateTime Updated { get; }
    string? Operation { get; }
    Status Status { get; }
    string? Currency { get; }
    Amount VatAmount { get; }
    Amount Amount { get; }
    string? Description { get; }
    string? InitiatingSystemUserAgent { get; }
    Language Language { get; }
    string[]? AvailableInstruments { get; }
    string? Implementation { get; }
    bool InstrumentMode { get; }
    bool GuestMode { get; }
    PayerResponse? Payer { get; }
    OrderItemsResponse? OrderItems { get; } 
    Urls? Urls { get; }
    HistoryResponse? History { get; }
    FailedResponse? Failed { get; }
    AbortedResponse? Aborted { get; }
    PaidResponse? Paid { get; }
    CancelledResponse? Cancelled { get; }
    FinancialTransactionsResponse? FinancialTransactions { get; }
    FailedAttemptsResponse? FailedAttempts { get; }
    Metadata? Metadata { get; }
}

public class PaymentOrder : Identifiable, IPaymentOrder
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
    public bool InstrumentMode { get; }
    public bool GuestMode { get; }
    public PayerResponse? Payer { get; }
    public OrderItemsResponse? OrderItems { get; }
    public Urls? Urls { get; }
    public HistoryResponse? History { get; }
    public FailedResponse? Failed { get; }
    public AbortedResponse? Aborted { get; }
    public PaidResponse? Paid { get; }
    public CancelledResponse? Cancelled { get; }
    public FinancialTransactionsResponse? FinancialTransactions { get; }
    public FailedAttemptsResponse? FailedAttempts { get; }
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
        InstrumentMode = paymentOrderResponseItemDto.InstrumentMode;
        GuestMode = paymentOrderResponseItemDto.GuestMode;
        Payer = paymentOrderResponseItemDto.Payer?.Map();
        OrderItems = paymentOrderResponseItemDto.OrderItems?.Map();
        Urls = paymentOrderResponseItemDto.Urls?.Map();
        History = paymentOrderResponseItemDto.History?.Map();
        Failed = paymentOrderResponseItemDto.Failed?.Map();
        Aborted = paymentOrderResponseItemDto.Aborted?.Map();
        Paid = paymentOrderResponseItemDto.Paid?.Map();
        Cancelled = paymentOrderResponseItemDto.Cancelled?.Map();
        FinancialTransactions = paymentOrderResponseItemDto.FinancialTransactions?.Map();
        FailedAttempts = paymentOrderResponseItemDto.FailedAttempts?.Map();
        Metadata = paymentOrderResponseItemDto.Metadata?.Map();
    }
}

public class OrderItemsResponse : Identifiable
{
    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<OrderItem>? OrderItemList { get; }

    internal OrderItemsResponse(OrderItemResponseDto dto) : base(dto.Id)
    {
        OrderItemList = dto.OrderItemList?.Select(item => item.Map()).ToList();
    }
}

public class AbortedResponse : Identifiable
{
    public string? AbortReason { get; }

    internal AbortedResponse(AbortedResponseDto dto) : base(dto.Id)
    {
        AbortReason = dto.AbortReason;
    }
}

public class CancelledDetails
{
    public string? NonPaymentToken { get; }
    public string? ExternalNonPaymentToken { get; }

    internal CancelledDetails(CancelledDetailsDto dto)
    {
        NonPaymentToken = dto.NonPaymentToken;
        ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
    }
}

public class CancelledResponse : Identifiable
{
    public string? CancelReason { get; }
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public string? OrderReference { get; }
    public string? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<TokenItem>? Tokens { get; }
    public CancelledDetails? Details { get; }

    internal CancelledResponse(CancelledResponseDto dto) : base(dto.Id)
    {
        CancelReason = dto.CancelReason;
        Instrument = dto.Instrument;
        Number = dto.Number;
        PayeeReference = dto.PayeeReference;
        OrderReference = dto.OrderReference;
        TransactionType = dto.TransactionType;
        Amount = new Amount(dto.Amount);
        SubmittedAmount = new Amount(dto.SubmittedAmount);
        FeeAmount = new Amount(dto.FeeAmount);
        DiscountAmount = new Amount(dto.DiscountAmount);
        Tokens = dto.Tokens?.Select(x => x.Map()).ToList();
        Details = dto.Details?.Map();
    }
}

public class FailedResponse : Identifiable
{
    public Problem? Problem { get; }

    internal FailedResponse(FailedResponseDto dto) : base(dto.Id)
    {
        Problem = dto.Problem?.Map();
    }
}

public class FailedAttemptListItem
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? Status { get; set; }
    public Problem? Problem { get; set; }

    internal FailedAttemptListItem(FailedAttemptListItemDto dto)
    {
        Created = dto.Created;
        Instrument = dto.Instrument;
        Number = dto.Number;
        Status = dto.Status;
        Problem = dto.Problem?.Map();
    }
}

public class FailedAttemptsResponse : Identifiable
{
    public IList<FailedAttemptListItem>? FailedAttemptList { get; set; }

    internal FailedAttemptsResponse(FailedAttemptsResponseDto dto) : base(dto.Id)
    {
        FailedAttemptList = dto.FailedAttemptList?.Select(x => x.Map()).ToList();
    }
}

public class FinancialTransactionListItem : Identifiable
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string? Type { get; set; }
    public long Number { get; set; }
    public Amount Amount { get; set; }
    public Amount VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }
    public IIdentifiable? OrderItems { get; set; }

    internal FinancialTransactionListItem(FinancialTransactionListItemDto dto) : base(dto.Id)
    {
        Created = dto.Created;
        Updated = dto.Updated;
        Type = dto.Type;
        Number = dto.Number;
        Amount = new Amount(dto.Amount);
        VatAmount = new Amount(dto.VatAmount);
        Description = dto.Description;
        PayeeReference = dto.PayeeReference;
        ReceiptReference = dto.ReceiptReference;
        OrderItems = dto.OrderItems != null ? new Identifiable(dto.OrderItems) : null;
    }
}


public class FinancialTransactionsResponse : Identifiable
{
    public IList<FinancialTransactionListItem>? FinancialTransactionsList { get; set; }
    
    internal FinancialTransactionsResponse(FinancialTransactionsResponseDto dto) : base(dto.Id)
    {
        FinancialTransactionsList = dto.FinancialTransactionsList?.Select(x => x.Map()).ToList();
    }
}

public class HistoryListItem
{
    public DateTime Created { get; }
    public string? Name { get; }
    public string? Instrument { get; }
    public long? Number { get; }
    public string? InitiatedBy { get; }
    public bool? Prefill { get; }

    internal HistoryListItem(HistoryListItemDto dto)
    {
        Created = dto.Created;
        Name = dto.Name;
        Instrument = dto.Instrument;
        Number = dto.Number;
        InitiatedBy = dto.InitiatedBy;
        Prefill = dto.Prefill;
    }
}

public class HistoryResponse : Identifiable
{
    public IList<HistoryListItem>? HistoryList { get; }

    internal HistoryResponse(HistoryResponseDto dto) : base(dto.Id)
    {
        HistoryList = dto.HistoryList?.Select(x => x.Map()).ToList();
    }
}

public class PaidDetails
{
    public string? NonPaymentToken { get; }
    public string? ExternalNonPaymentToken { get; }
    public string? PaymentAccountReference { get; }
    public string? CardBrand { get; }
    public string? CardType { get; }
    public string? MaskedPan { get; }
    public string? MaskedDPan { get; }
    public string? ExpiryDate { get; }
    public string? IssuerAuthorizationApprovalCode { get; }
    public string? AcquirerTransactionType { get; }
    public string? AcquirerStan { get; }
    public string? AcquirerTerminalId { get; }
    public string? AcquirerTransactionTime { get; }
    public string? TransactionInitiator { get; }
    public string? Bin { get; }
    public string? Msisdn { get; }

    internal PaidDetails(PaidDetailsDto dto)
    {
        NonPaymentToken = dto.NonPaymentToken;
        ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
        PaymentAccountReference = dto.PaymentAccountReference;
        CardBrand = dto.CardBrand;
        CardType = dto.CardType;
        MaskedPan = dto.MaskedPan;
        MaskedDPan = dto.MaskedDPan;
        ExpiryDate = dto.ExpiryDate;
        IssuerAuthorizationApprovalCode = dto.IssuerAuthorizationApprovalCode;
        AcquirerTransactionType = dto.AcquirerTransactionType;
        AcquirerStan = dto.AcquirerStan;
        AcquirerTerminalId = dto.AcquirerTerminalId;
        AcquirerTransactionTime = dto.AcquirerTransactionTime;
        TransactionInitiator = dto.TransactionInitiator;
        Bin = dto.Bin;
        Msisdn = dto.Msisdn;
    }
}

public class TokenItem
{
    public string? Type { get; }
    public string? Token { get; }
    public string? Name { get; }
    public string? ExpiryDate { get; }

    internal TokenItem(TokenItemDto dto)
    {
        Type = dto.Type;
        Token = dto.Token;
        Name = dto.Name;
        ExpiryDate = dto.ExpiryDate;
    }
}

public class PaidResponse : Identifiable
{
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public string? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<TokenItem>? Tokens { get; }
    public PaidDetails? Details { get; }

    internal PaidResponse(PaidResponseDto dto) : base(dto.Id)
    {
        Instrument = dto.Instrument;
        Number = dto.Number;
        PayeeReference = dto.PayeeReference;
        TransactionType = dto.TransactionType;
        Amount = new Amount(dto.Amount);
        SubmittedAmount = new Amount(dto.SubmittedAmount);
        FeeAmount = new Amount(dto.FeeAmount);
        DiscountAmount = new Amount(dto.DiscountAmount);
        Tokens = dto.Tokens?.Select(x => x.Map()).ToList();
        Details = dto.Details?.Map();
    }
}

public class Device
{
    public int DetectionAccuracy { get; }
    public string? IpAddress { get; }
    public string? UserAgent { get; }
    public string? DeviceType { get; }
    public string? HardwareFamily { get; }
    public string? HardwareName { get; }
    public string? HardwareVendor { get; }
    public string? PlatformName { get; }
    public string? PlatformVendor { get; }
    public string? PlatformVersion { get; }
    public string? BrowserName { get; }
    public string? BrowserVendor { get; }
    public string? BrowserVersion { get; }
    public bool BrowserJavaEnabled { get; }
    
    internal Device(DeviceDto dto)
    {
        DetectionAccuracy = dto.DetectionAccuracy;
        IpAddress = dto.IpAddress;
        UserAgent = dto.UserAgent;
        DeviceType = dto.DeviceType;
        HardwareFamily = dto.HardwareFamily;
        HardwareName = dto.HardwareName;
        HardwareVendor = dto.HardwareVendor;
        PlatformName = dto.PlatformName;
        PlatformVendor = dto.PlatformVendor;
        PlatformVersion = dto.PlatformVersion;
        BrowserName = dto.BrowserName;
        BrowserVendor = dto.BrowserVendor;
        BrowserVersion = dto.BrowserVersion;
        BrowserJavaEnabled = dto.BrowserJavaEnabled;
    }
}

public class PayerResponse : Identifiable
{
    public Device? Device { get; }
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
    }
}