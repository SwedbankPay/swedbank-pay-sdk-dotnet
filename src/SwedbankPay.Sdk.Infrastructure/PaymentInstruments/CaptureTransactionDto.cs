using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureTransactionDto : List<PaymentOrderTransactionDto>
    {
        public Uri Id { get; set; }

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in this)
            {
                list.Add(new TransactionResponse(Id?.OriginalString, item));
            }
            return new CapturesListResponse(Id, list);
        }
    }
}