using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class ReversalTransactionListResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> Reversal { get; set; }

        internal IReversalsListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var r in Reversal)
            {
                list.Add(new TransactionResponse(Id.OriginalString, r));
            }
            return new ReversalsListResponse(Id, list);
        }
    }
}