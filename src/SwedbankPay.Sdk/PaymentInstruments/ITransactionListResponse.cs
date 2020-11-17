using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransactionListResponse
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this transaction list.
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// List of available transactions for the current payment.
        /// </summary>
        List<ITransaction> TransactionList { get; }
    }
}