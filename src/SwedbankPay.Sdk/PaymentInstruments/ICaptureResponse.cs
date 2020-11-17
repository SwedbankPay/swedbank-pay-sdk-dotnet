using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICaptureResponse
    {
        /// <summary>
        /// Unique <seealso cref="Uri"/> to access this capture.
        /// </summary>
        Uri Payment { get; }

        /// <summary>
        /// Transactional information about this capture.
        /// </summary>
        ITransaction Capture { get; }
    }
}