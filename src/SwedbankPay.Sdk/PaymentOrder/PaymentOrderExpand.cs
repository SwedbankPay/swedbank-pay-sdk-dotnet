namespace SwedbankPay.Sdk.PaymentOrder;

/// <summary>
/// Use to have sub-resources of a payment order be automatically expanded/filled
/// when using a GET request for a payment order.
/// </summary>
[Flags]
public enum PaymentOrderExpand
{
    /// <summary>
    /// Don't expand any fields.
    /// </summary>
    None = 0,

    /// <summary>
    /// Expand the Order items sub-resource.
    /// </summary>
    OrderItems = 1,

    /// <summary>
    /// Expand the Urls sub-resource.
    /// </summary>
    Urls = 2,

    /// <summary>
    /// Expand the Payee info sub-resource.
    /// </summary>
    PayeeInfo = 4,

    /// <summary>
    /// Expand the Payer sub-resource.
    /// </summary>
    Payer = 8,

    /// <summary>
    /// Expand the History sub-resource.
    /// </summary>
    History = 16,

    /// <summary>
    /// Expand the Failed sub-resource.
    /// </summary>
    Failed = 32,

    /// <summary>
    /// Expand the Aborted sub-resource.
    /// </summary>
    Aborted = 64,

    /// <summary>
    /// Expand the Paid sub-resource.
    /// </summary>
    Paid = 128,
    
    /// <summary>
    /// Expand the Cancelled sub-resource.
    /// </summary>
    Cancelled = 256, 
    
    /// <summary>
    /// Expand the Financial transactions sub-resource.
    /// </summary>
    FinancialTransactions = 512,
    
    /// <summary>
    /// Expand the Failed attempts sub-resource.
    /// </summary>
    FailedAttempts = 1024,
    
    /// <summary>
    /// Expand the Post Purchase Failed Attempts sub-resource.
    /// </summary>
    PostPurchaseFailedAttempts = 2048,
    
    /// <summary>
    /// Expand the Meta data sub-resource.
    /// </summary>
    MetaData = 4096,
    
    /// <summary>
    /// Expand All sub-resources.
    /// </summary>
    All = 8191
}