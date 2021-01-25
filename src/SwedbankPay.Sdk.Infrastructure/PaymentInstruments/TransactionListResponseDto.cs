using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class TransactionListResponseDto
    {
        public string Id { get; set; }

        public List<TransactionDto> TransactionList { get; set; } = new List<TransactionDto>();

        internal ITransactionListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in TransactionList)
            {
                transactionList.Add(t.Map());
            }
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new TransactionListResponse(uri, transactionList);
        }
    }
}