namespace SwedbankPay.Sdk.PaymentOrder;

internal record PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; set; } = null!;
    public IList<OperationResponseDto> Operations { get; set; } = new List<OperationResponseDto>();
}

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
    public bool InstrumentMode { get; set; }
    public bool GuestMode { get; set; }
    public PayerResponseDto? Payer { get; set; }
    public OrderItemResponseDto? OrderItems { get; set; }
    public UrlsDto? Urls { get; set; }
    public HistoryResponseDto? History { get; set; }
    public FailedResponseDto? Failed { get; set; }
    public AbortedResponseDto? Aborted { get; set; }
    public PaidResponseDto? Paid { get; set; }
    public CancelledResponseDto? Cancelled { get; set; }
    public FinancialTransactionsResponseDto? FinancialTransactions { get; set; }
    public FailedAttemptsResponseDto? FailedAttempts { get; set; }
    public MetadataDto? Metadata { get; set; }
}

internal record OrderItemResponseDto : IdentifiableDto
{
    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<OrderItemDto>? OrderItemList { get; set; }

    public OrderItemResponseDto(string id) : base(id)
    {
    }

    internal OrderItemsResponse Map()
    {
        return new OrderItemsResponse(this);
    }
}

internal record AbortedResponseDto : IdentifiableDto
{
    public string? AbortReason { get; set; }

    public AbortedResponseDto(string id) : base(id)
    {
    }

    public AbortedResponse Map()
    {
        return new AbortedResponse(this);
    }
}

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; set; }
    public string? ExternalNonPaymentToken { get; set; }

    public CancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}

internal record CancelledResponseDto : IdentifiableDto
{
    public string? CancelReason { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? PayeeReference { get; set; }
    public string? OrderReference { get; set; }
    public string? TransactionType { get; set; }
    public long Amount { get; set; }
    public long SubmittedAmount { get; set; }
    public long FeeAmount { get; set; }
    public long DiscountAmount { get; set; }
    public IList<TokenItemDto>? Tokens { get; set; }
    public CancelledDetailsDto? Details { get; set; }

    public CancelledResponseDto(string id) : base(id)
    {
    }

    public CancelledResponse Map()
    {
        return new CancelledResponse(this);
    }
}

internal record FailedResponseDto : IdentifiableDto
{
    public ProblemDto? Problem { get; set; }

    public FailedResponseDto(string id) : base(id)
    {
    }

    public FailedResponse Map()
    {
        return new FailedResponse(this);
    }
}

internal record FailedAttemptListItemDto
{
    public DateTime Created { get; set; }
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? Status { get; set; }
    public ProblemDto? Problem { get; set; }

    public FailedAttemptListItem Map()
    {
        return new FailedAttemptListItem(this);
    }
}

internal record FailedAttemptsResponseDto : IdentifiableDto
{
    public IList<FailedAttemptListItemDto>? FailedAttemptList { get; set; }

    public FailedAttemptsResponseDto(string id) : base(id)
    {
    }

    public FailedAttemptsResponse Map()
    {
        return new FailedAttemptsResponse(this);
    }
}

internal record FinancialTransactionListItemDto
{
    public string Id { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string? Type { get; set; }
    public long Number { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string? Description { get; set; }
    public string? PayeeReference { get; set; }
    public string? ReceiptReference { get; set; }
    public IdentifiableDto OrderItems { get; set; }

    public FinancialTransactionListItem Map()
    {
        return new FinancialTransactionListItem(this);
    }
}

internal record FinancialTransactionsResponseDto : IdentifiableDto
{
    public IList<FinancialTransactionListItemDto>? FinancialTransactionsList { get; set; }

    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }

    public FinancialTransactionsResponse Map()
    {
        return new FinancialTransactionsResponse(this);
    }
}

internal record HistoryListItemDto
{
    public DateTime Created { get; set; }
    public string? Name { get; set; }
    public string? Instrument { get; set; }
    public long? Number { get; set; }
    public string? InitiatedBy { get; set; }
    public bool? Prefill { get; set; }

    public HistoryListItem Map()
    {
        return new HistoryListItem(this);
    }
}

internal record HistoryResponseDto : IdentifiableDto
{
    public IList<HistoryListItemDto>? HistoryList { get; set; }

    public HistoryResponseDto(string id) : base(id)
    {
    }

    public HistoryResponse Map()
    {
        return new HistoryResponse(this);
    }
}

internal record PaidDetailsDto
{
    public string? NonPaymentToken { get; set; }
    public string? ExternalNonPaymentToken { get; set; }
    public string? PaymentAccountReference { get; set; }
    public string? CardBrand { get; set; }
    public string? CardType { get; set; }
    public string? MaskedPan { get; set; }
    public string? MaskedDPan { get; set; }
    public string? ExpiryDate { get; set; }
    public string? IssuerAuthorizationApprovalCode { get; set; }
    public string? AcquirerTransactionType { get; set; }
    public string? AcquirerStan { get; set; }
    public string? AcquirerTerminalId { get; set; }
    public string? AcquirerTransactionTime { get; set; }
    public string? TransactionInitiator { get; set; }
    public string? Bin { get; set; }
    public string? Msisdn { get; set; }

    public PaidDetails Map()
    {
        return new PaidDetails(this);
    }
}

internal record TokenItemDto
{
    public string? Type { get; set; }
    public string? Token { get; set; }
    public string? Name { get; set; }
    public string? ExpiryDate { get; set; }

    public TokenItem Map()
    {
        return new TokenItem(this);
    }
}

internal record PaidResponseDto : IdentifiableDto
{
    public string? Instrument { get; set; }
    public long Number { get; set; }
    public string? PayeeReference { get; set; }
    public string? OrderReference { get; set; }
    public string? TransactionType { get; set; }
    public long Amount { get; set; }
    public long SubmittedAmount { get; set; }
    public long FeeAmount { get; set; }
    public long DiscountAmount { get; set; }
    public IList<TokenItemDto>? Tokens { get; set; }
    public PaidDetailsDto? Details { get; set; }

    public PaidResponseDto(string id) : base(id)
    {
    }

    public PaidResponse Map()
    {
        return new PaidResponse(this);
    }
}

internal record DeviceDto
{
    public int DetectionAccuracy { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? DeviceType { get; set; }
    public string? HardwareFamily { get; set; }
    public string? HardwareName { get; set; }
    public string? HardwareVendor { get; set; }
    public string? PlatformName { get; set; }
    public string? PlatformVendor { get; set; }
    public string? PlatformVersion { get; set; }
    public string? BrowserName { get; set; }
    public string? BrowserVendor { get; set; }
    public string? BrowserVersion { get; set; }
    public bool BrowserJavaEnabled { get; set; }

    public Device Map()
    {
        return new Device(this);
    }
}

internal record PayerResponseDto : IdentifiableDto
{
    public DeviceDto? Device { get; set; }
    
    public PayerResponseDto(string id) : base(id)
    {
    }

    public PayerResponse Map()
    {
        return new PayerResponse(this);
    }
}