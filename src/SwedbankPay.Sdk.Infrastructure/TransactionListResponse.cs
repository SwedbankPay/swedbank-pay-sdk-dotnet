using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk;

internal class TransactionListResponse : Identifiable, ITransactionListResponse
{
    public TransactionListResponse(Uri id, List<ITransaction> transactionList)
        : base(id)
    {
        TransactionList = transactionList;
    }


    public IList<ITransaction> TransactionList { get; }
}