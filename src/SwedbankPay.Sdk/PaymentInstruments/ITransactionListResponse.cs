using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object holding available a transaction list.
    /// </summary>
    public interface ITransactionListResponse : IIdentifiable
    {
        /// <summary>
        /// List of available transactions for the current payment.
        /// </summary>
        IList<ITransaction> TransactionList { get; }
    }
}