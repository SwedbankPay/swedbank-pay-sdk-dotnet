using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Object describing a Swish sale item.
    /// </summary>
    public interface ISwishSaleListItem : IIdentifiable
    {
        /// <summary>
        /// Shows the <seealso cref="DateTime"/> this sale object was created.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// The payers <seealso cref="Msisdn"/>.
        /// </summary>
        public string PayerAlias { get; }

        /// <summary>
        /// In the M-Commerce payment flow this is set as a reference
        /// to use with Swish.
        /// </summary>
        public string PaymentRequestToken { get; }

        /// <summary>
        /// Reference to find the payment in Swish systems.
        /// </summary>
        public string SwishPaymentReference { get; }

        /// <summary>
        /// Last known state of this payment from Swish.
        /// </summary>
        public string SwishStatus { get; }

        /// <summary>
        /// The current sales transaction for this sale item.
        /// </summary>
        public ITransaction Transaction { get; }
    }
}