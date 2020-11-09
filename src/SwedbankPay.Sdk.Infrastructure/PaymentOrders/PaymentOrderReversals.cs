using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversals
    {
        public string Id { get; set; }
        public List<TransactionDto> ReversalList { get; set; } = new List<TransactionDto>();

        internal IReversalsListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in ReversalList)
            {
                list.Add(new TransactionResponse(Id, item));
            }
            return new ReversalsListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}