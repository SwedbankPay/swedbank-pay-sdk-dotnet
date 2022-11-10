using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Transactional details for capturing a invoice payment.
/// </summary>
public interface ICaptureTransaction
{
    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> to be captured.
    /// </summary>
    Amount Amount { get; }

    /// <summary>
    /// A description of what is being captured.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// A list describing each item being captured in this request.
    /// </summary>
    IList<ItemDescription> ItemDescriptions { get; set; }

    /// <summary>
    /// List of <seealso cref="IOrderItem"/> to be captured in this transaction.
    /// </summary>
    IList<IOrderItem> OrderItems { get; }

    /// <summary>
    /// The payeeReference is the receipt/invoice number if receiptReference is not defined,
    /// which is a unique reference with max 50 characters set by the merchant system.
    /// This must be unique for each operation and must follow the regex pattern [\w-]*.
    /// </summary>
    string PayeeReference { get; }

    /// <summary>
    /// The API operation to be used.
    /// </summary>
    Operation TransactionActivity { get; set; }

    /// <summary>
    /// The total Value Added Tax <seealso cref="Sdk.Amount"/> being captured.
    /// </summary>
    Amount VatAmount { get; }

    /// <summary>
    /// A list describing each items vat summary.
    /// </summary>
    IList<VatSummary> VatSummary { get; set; }
}