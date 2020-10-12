using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public interface ITransactionListResponse
    {
        List<Transaction> TransactionList { get; }
    }
}