using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class TransactionListResponse : IdLink, ITransactionListResponse
    {
        public TransactionListResponse(Uri id, List<Transaction> transactionList)
        {
            Id = id;
            TransactionList = transactionList;
        }


        public List<Transaction> TransactionList { get; }
    }
}