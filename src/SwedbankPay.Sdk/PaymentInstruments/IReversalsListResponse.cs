using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IReversalsListResponse
    {
        /// <summary>
        /// Contains a list of available reversal transactions.
        /// </summary>
        List<ITransactionResponse> ReversalList { get; }
    }
}