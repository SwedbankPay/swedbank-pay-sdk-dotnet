using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderReversals
    {
        public Uri Id { get; set; }
        public List<TransactionDto> Reversals { get; set; } = new List<TransactionDto>();

        internal IReversalsListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in Reversals)
            {
                list.Add(new TransactionResponse(Id, item));
            }

            return new ReversalsListResponse(Id, list);
        }
    }
}