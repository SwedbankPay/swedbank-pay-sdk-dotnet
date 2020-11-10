using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ReversalsListResponseDto
    {
        public string Id { get; set; }
        public TransactionDto Reversal { get; set; } 
        internal IReversalsListResponse Map()
        {
            var list = new List<ITransactionResponse>
            {
                new TransactionResponse(Id, Reversal)
            };

            return new ReversalsListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}