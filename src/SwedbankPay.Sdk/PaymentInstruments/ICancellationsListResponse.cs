using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICancellationsListResponse
    {
        /// <summary>
        /// List of transactional cancellations.
        /// </summary>
        List<ITransaction> CancellationList { get; }
    }
}