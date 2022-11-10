namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Transactional details about a invoice payment.
/// Involves what the fee to charge a payer if selected.
/// </summary>
public class Invoice
{
    /// <summary>
    ///     The fee amount in the lowest monetary unit to apply if the consumer chooses to pay with invoice.
    /// </summary>
    public int? FeeAmount { get; set; }
}