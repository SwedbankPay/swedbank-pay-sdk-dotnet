using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationsListResponseDto
    {
        public List<PaymentOrderTransactionDto> CancellationList { get; set; }
        public Uri Id { get; set; }

        internal ICancellationsListResponse Map()
        {
            var transactionList = new List<ITransactionResponse>();
            foreach (var t in CancellationList)
            {
                transactionList.Add(new TransactionResponse(t.Id, t));
            }
            return new CancellationsListResponse(Id, transactionList);
        }
    }
}