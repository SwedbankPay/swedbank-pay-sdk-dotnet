using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationTransactionDto : List<PaymentOrderTransactionDto>
    {
        public string Id { get; set; }

        internal ICancellationsListResponse Map()
        {
            var list = new List<ITransactionResponse>();
            foreach (var item in this)
            {
                list.Add(new TransactionResponse(item.Id, item));
            }
            return new CancellationsListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}