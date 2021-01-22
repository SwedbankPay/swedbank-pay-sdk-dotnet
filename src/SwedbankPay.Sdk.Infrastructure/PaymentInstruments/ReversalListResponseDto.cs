using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class ReversalListResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> ReversalList { get; set; } = new List<TransactionDto>();

        internal IReversalListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in ReversalList)
            {
                list.Add(new TransactionResponse(Id, item));
            }

            return new ReversalListResponse(Id, list);
        }
    }
}