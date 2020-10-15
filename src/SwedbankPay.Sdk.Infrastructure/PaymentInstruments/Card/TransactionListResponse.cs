using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
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