using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureTransactionResponseDto
    {
        public Uri Id { get; set; }
        public string Payment { get; set; }
        public List<TransactionDto> Capture { get; set; } = new List<TransactionDto>();

        internal ICapturesListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            foreach (var t in Capture)
            {
                transactionList.Add(t.Map());
            }
            return new CapturesListResponse(Id, transactionList);
        }
    }

}