using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class CaptureTransactionResponseDto
    {
        public Uri Id { get; set; }
        public string Payment { get; set; }
        public List<TransactionDto> Capture { get; set; }

        internal ICapturesListResponse Map()
        {
            var transactionList = new List<ITransactionResponse>();
            foreach (var t in Capture)
            {
                transactionList.Add(new TransactionResponse(t.Id, t));
            }
            return new CapturesListResponse(Id, transactionList);
        }
    }

}