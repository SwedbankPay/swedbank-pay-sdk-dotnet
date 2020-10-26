using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationTransactionDto
    {
        public string Id { get; set; }

        public List<TransactionDto> Cancellations { get; set; }

        internal ICancellationsListResponse Map()
        {
            var list = new List<ITransaction>();
            foreach (var item in Cancellations)
            {
                list.Add(item.Map());
            }
            return new CancellationsListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}