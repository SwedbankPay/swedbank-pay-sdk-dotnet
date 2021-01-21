using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CaptureListTransactionDto
    {
        public Uri Id { get; set; }

        public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransaction>();
            foreach (var c in CaptureList)
            {
                list.Add(c.Map());
            }
            return new CapturesListResponse(Id, list);
        }
    }
}