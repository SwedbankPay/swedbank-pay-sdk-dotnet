using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderTransactions
    {
        public string Id { get; set; }
        public List<PaymentOrderTransactionListDto> TransactionList { get; set; }
    }
}