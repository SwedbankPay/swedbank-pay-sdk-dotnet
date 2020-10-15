using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransactionListResponse
    {
        List<Transaction> TransactionList { get; }
    }
}