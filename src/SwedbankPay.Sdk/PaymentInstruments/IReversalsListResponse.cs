using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object holding a list of available reversals on a payment.
    /// </summary>
    public interface IReversalsListResponse
    {
        /// <summary>
        /// Contains a list of available reversal transactions.
        /// </summary>
        List<ITransactionResponse> ReversalList { get; }
    }
}