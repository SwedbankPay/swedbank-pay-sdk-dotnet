using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderTransactionsDto
    {
        public string Id { get; set; }
        public List<PaymentOrderTransactionListDto> TransactionList { get; set; }

        internal ITransactionListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}