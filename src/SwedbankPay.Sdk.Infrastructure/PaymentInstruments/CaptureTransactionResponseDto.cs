using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CaptureTransactionResponseDto
    {
        public Uri Id { get; set; }
        public string Payment { get; set; }
        public TransactionDto Capture { get; set; }

        internal ICaptureListResponse Map()
        {
            var transactionList = new List<ITransaction>();
            if(Capture != null) {
                transactionList.Add(Capture.Map());
            }
            return new CaptureListResponse(Id, transactionList);
        }
    }

}