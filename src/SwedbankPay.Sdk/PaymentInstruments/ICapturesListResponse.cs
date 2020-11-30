using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// List of transactional details of a captured payment.
    /// </summary>
    public interface ICapturesListResponse
    {
        /// <summary>
        /// List of transactional information about capture(s).
        /// </summary>
        List<ITransaction> CaptureList { get; }
    }
}