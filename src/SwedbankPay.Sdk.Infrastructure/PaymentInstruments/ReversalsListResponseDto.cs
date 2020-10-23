using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ReversalsListResponseDto
    {
        public string Id { get; set; }
        List<TransactionDto> ReversalList { get; set; }
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