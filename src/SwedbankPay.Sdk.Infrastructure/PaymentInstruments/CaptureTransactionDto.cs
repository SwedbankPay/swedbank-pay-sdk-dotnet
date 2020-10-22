using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureTransactionDto : List<PaymentOrderTransactionDto>
    {
        public string Id { get; set; }

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in this)
            {
                list.Add(new TransactionResponse(item.Id, item));
            }
            return new CapturesListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}