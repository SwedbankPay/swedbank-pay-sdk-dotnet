using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishPaymentSale
    {
        /// <summary>
        /// The <seealso cref="Uri"/> to access this payment
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// Shows when the payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// When the current payment was last updated.
        /// </summary>
        DateTime Updated { get; }
        string PaymentRequestToken { get; }

        /// <summary>
        /// Information about the current transaction of the payment.
        /// </summary>
        ITransaction Transaction { get; }
    }
}