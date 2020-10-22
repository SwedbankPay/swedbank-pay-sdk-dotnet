using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentOrders;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class TransactionResponse : IdLink, ITransactionResponse
    {
        public TransactionResponse(string id, PaymentOrderTransactionDto transaction)
        {
            Id = new Uri(id, UriKind.RelativeOrAbsolute);
            Transaction = transaction.Map();
        }

        public ITransaction Transaction { get; }
    }
}