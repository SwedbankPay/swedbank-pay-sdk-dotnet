using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Object describing a Swish sale item.
/// </summary>
internal class SwishSaleListItem : ISwishSaleListItem
{
    public SwishSaleListItem(SaleListItemDto swishSaleListItem)
    {
        Date = swishSaleListItem.Date;
        PaymentRequestToken = swishSaleListItem.PaymentRequestToken;
        PayerAlias = swishSaleListItem.PayerAlias;
        SwishPaymentReference = swishSaleListItem.SwishPaymentReference;
        SwishStatus = swishSaleListItem.SwishStatus;
        Id = swishSaleListItem.Id;
        Transaction = swishSaleListItem.Transaction.Map();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Uri Id { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string PayerAlias { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string PaymentRequestToken { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string SwishPaymentReference { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string SwishStatus { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ITransaction Transaction { get; }
}