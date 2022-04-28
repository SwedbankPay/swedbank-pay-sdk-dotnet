using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Transactional details about a captured payment.
    /// </summary>
    public interface ICaptureResponse
    {
        /// <summary>
        /// Unique <seealso cref="Uri"/> to access this capture.
        /// </summary>
        Uri Payment { get; }

        /// <summary>
        /// Transactional information about this capture.
        /// </summary>
        ITransactionResponse Capture { get; }
    }
}