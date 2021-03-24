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
        DateTime Date { get; }

        /// <summary>
        /// The payers <seealso cref="Msisdn"/>.
        /// </summary>
        string PayerAlias { get; }

        /// <summary>
        /// In the M-Commerce payment flow this is set as a reference
        /// to use with Swish.
        /// </summary>
        string PaymentRequestToken { get; }

        /// <summary>
        /// Reference to find the payment in Swish systems.
        /// </summary>
        string SwishPaymentReference { get; }

        /// <summary>
        /// Last known state of this payment from Swish.
        /// </summary>
        string SwishStatus { get; }

        /// <summary>
        /// The current sales transaction for this sale item.
        /// </summary>
        ITransaction Transaction { get; }
    }
}