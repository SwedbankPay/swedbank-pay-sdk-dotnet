using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Object describing a Swish sale item.
    /// </summary>
    public class SwishSaleListItem : ISwishSaleListItem
    {
        /// <summary>
        /// Instantiates a new <see cref="SwishSaleListItem"/> with the provided parameters.
        /// </summary>
        /// <param name="id">The unique reference to this sale list item.</param>
        /// <param name="date">The <seealso cref="DateTime"/> this item was created.</param>
        /// <param name="paymentRequestToken">Reference token used in Swish systems.</param>
        /// <param name="payerAlias">The payers <seealso cref="Msisdn"/>.</param>
        /// <param name="swishPaymentReference">Reference token used in Swish systems.</param>
        /// <param name="swishStatus">Last known status about the payment from Swish.</param>
        /// <param name="transaction">Transactional details about the sale list item.</param>
        public SwishSaleListItem(Uri id,
                            DateTime date,
                            string paymentRequestToken,
                            string payerAlias,
                            string swishPaymentReference,
                            string swishStatus,
                            ITransaction transaction)
        {
            Date = date;
            PaymentRequestToken = paymentRequestToken;
            PayerAlias = payerAlias;
            SwishPaymentReference = swishPaymentReference;
            SwishStatus = swishStatus;
            Id = id;
            Transaction = transaction;
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
}