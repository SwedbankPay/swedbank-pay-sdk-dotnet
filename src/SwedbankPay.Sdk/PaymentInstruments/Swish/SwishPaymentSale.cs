using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Describes a Swish payment response using the Sale operation.
    /// </summary>
    public class SwishPaymentSale : ISwishPaymentSale
    {
        /// <summary>
        /// Instantiates a new <see cref="SwishPaymentSale"/> with the provided parameters.
        /// </summary>
        /// <param name="id">The unique ID of this payment.</param>
        /// <param name="created">The time this sale was created.</param>
        /// <param name="updated">The time this sale was last updated.</param>
        /// <param name="paymentRequestToken">Reference to the payment in Swish systems.</param>
        /// <param name="transaction">Transactional information about this payment.</param>
        public SwishPaymentSale(Uri id, DateTime created, DateTime updated, string paymentRequestToken, ITransaction transaction)
        {
            Created = created;
            Updated = updated;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PaymentRequestToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ITransaction Transaction { get; }
    }
}