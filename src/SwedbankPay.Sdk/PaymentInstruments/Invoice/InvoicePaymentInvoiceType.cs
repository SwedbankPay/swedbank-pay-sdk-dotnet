namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Enum detailing the available invoice types.
/// </summary>
public enum InvoiceType
{
    /// <summary>
    /// The invoice type is unknown.
    /// </summary>
    Unknown = default,

    /// <summary>
    /// <see cref="InvoiceType"/> used for norwegian invoices.
    /// </summary>
    PayExFinancingNo,
    
    /// <summary>
    /// <see cref="InvoiceType"/> used for finish invoices.
    /// </summary>
    PayExFinancingFi,
    
    /// <summary>
    /// <see cref="InvoiceType"/> used for swedish invoices.
    /// </summary>
    PayExFinancingSe
}