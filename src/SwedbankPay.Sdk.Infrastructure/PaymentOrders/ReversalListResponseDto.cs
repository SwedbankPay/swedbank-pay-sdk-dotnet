using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class ReversalListResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> Reversals { get; set; } = new List<TransactionDto>();

        internal IReversalListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in Reversals)
            {
                list.Add(new TransactionResponse(Id, item));
            }

            return new ReversalListResponse(Id, list);
        }
    }
}