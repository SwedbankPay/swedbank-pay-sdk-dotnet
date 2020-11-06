using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureTransactionResponseDto
    {
        public Uri Id { get; set; }
        public string Payment { get; set; }
        public TransactionDto Capture { get; set; }

        internal ICapturesListResponse Map()
        {
            var transactionList = new List<ITransaction>
            {
                Capture.Map()
            };
            return new CapturesListResponse(Id, transactionList);
        }
    }

}