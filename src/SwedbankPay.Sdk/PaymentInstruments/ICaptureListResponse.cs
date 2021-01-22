using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// List of transactional details of a captured payment.
    /// </summary>
    public interface ICaptureListResponse
    {
        /// <summary>
        /// List of transactional information about capture(s).
        /// </summary>
        IList<ITransaction> CaptureList { get; }
    }
}