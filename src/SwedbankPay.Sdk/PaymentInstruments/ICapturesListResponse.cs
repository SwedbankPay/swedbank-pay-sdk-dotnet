using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICapturesListResponse
    {
        /// <summary>
        /// List of transactional information about capture(s).
        /// </summary>
        List<ITransaction> CaptureList { get; }
    }
}