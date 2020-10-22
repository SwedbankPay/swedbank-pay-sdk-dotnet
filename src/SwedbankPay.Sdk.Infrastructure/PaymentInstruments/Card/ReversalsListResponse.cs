using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class ReversalsListResponse : IdLink, IReversalsListResponse
    {
        public ReversalsListResponse(Uri id, List<PaymentOrderReversalListDto> reversalList)
        {
            Id = id;
            ReversalList = new List<TransactionResponse>();
            foreach (var rev in reversalList)
            {
                var item = new TransactionResponse(rev.Id, rev.Transaction);
                ReversalList.Add(item);
            }
        }

        public List<ITransactionResponse> ReversalList { get; }
    }
}