using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureTransactionDto
    {
        public Uri Id { get; set; }

        public List<TransactionDto> Captures { get; set; }

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in Captures)
            {
                list.Add(new TransactionResponse(Id?.OriginalString, item));
            }
            return new CapturesListResponse(Id, list);
        }
    }
}