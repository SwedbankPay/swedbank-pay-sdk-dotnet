using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class ReversalsListDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> ReversalList { get; set; } = new List<TransactionDto>();

        internal IReversalsList Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in ReversalList)
            {
                list.Add(new TransactionResponse(Id, item));
            }

            return new ReversalsList(Id, list);
        }
    }
}