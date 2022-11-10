using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Resource describing a item involved in a sale operation.
/// </summary>
public interface ISaleListItem
{
    /// <summary>
    /// A unique <seealso cref="Uri"/>
    /// </summary>
    public Uri Id { get; }

    /// <summary>
    /// The <seealso cref="DateTime"/> this sale list item was created.
    /// </summary>
    public DateTime Created { get; }

    /// <summary>
    /// The <seealso cref="DateTime"/> this sale list item was last updated.
    /// </summary>
    public DateTime Updated { get; }

    /// <summary>
    /// Indicates the payment type used to pay for this sale list item.
    /// </summary>
    public PaymentType Type { get; }

    /// <summary>
    /// ndicates the state of the payment, not the state of any transactions performed on the payment.
    /// To find the state of the payment’s transactions (such as a successful authorization),
    /// see the transactions resource or the different specialized type-specific resources such as authorizations or sales.
    /// </summary>
    public State State { get; }

    /// <summary>
    /// The payment number , useful when there’s need to reference the payment in human communication.
    /// Not usable for programmatic identification of the payment, for that <see cref="Id"/> should be used instead.
    /// </summary>
    public long Number { get; }

    /// <summary>
    /// The amount (including VAT, if any) to charge the payer, entered in the lowest monetary unit of the selected currency.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
    /// This field is used to specify how much of the total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    public Amount VatAmount { get; }

    /// <summary>
    /// A 40 character length textual description of the purchase.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    public string PayeeReference { get; }
}