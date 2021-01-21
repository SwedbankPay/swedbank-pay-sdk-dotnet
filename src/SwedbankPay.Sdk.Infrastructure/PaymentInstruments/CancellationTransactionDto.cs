using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancellationTransactionDto
    {
        public string Id { get; set; }

        public List<TransactionDto> CancellationList { get; set; } = new List<TransactionDto>();

        internal ICancellationsList Map()
        {
            var list = new List<ITransaction>();
            foreach (var item in CancellationList)
            {
                list.Add(item.Map());
            }
            return new CancellationsList(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}