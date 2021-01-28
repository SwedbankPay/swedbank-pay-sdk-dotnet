using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object holding possible reversals on a payment.
    /// </summary>
    public interface IReversalResponse
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this reversal.
        /// </summary>
        Uri Payment { get; }

        /// <summary>
        /// Transactional reversal information.
        /// </summary>
        ITransactionResponse Reversal { get; }
    }
}