using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// List of transactional details on a cancelled payment.
    /// </summary>
    public interface ICancellationsList
    {
        /// <summary>
        /// List of transactional cancellations.
        /// </summary>
        IList<ITransaction> CancellationList { get; }
    }
}