namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Wrapper for transactional details on a invoice.
/// </summary>
public interface IInvoiceDetails
{
    /// <summary>
    /// The type this invoice was created with.
    /// </summary>
    InvoiceType InvoiceType { get; }
}