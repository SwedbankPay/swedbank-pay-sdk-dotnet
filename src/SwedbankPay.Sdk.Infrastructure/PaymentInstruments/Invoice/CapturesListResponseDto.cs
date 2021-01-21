using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class CapturesListResponseDto
    {
        public Uri Id { get; set; }
        public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

        internal ICapturesListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in CaptureList)
            {
                transactionList.Add(t.Map());
            }
            return new CapturesListResponse(Id, transactionList);
        }
    }
}