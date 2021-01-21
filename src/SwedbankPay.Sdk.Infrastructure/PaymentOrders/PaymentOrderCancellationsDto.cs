using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCancellationsDto
    {
        public string Id { get; set; }
        public TransactionDto Cancellation { get; set; }

        internal ICancellationsList Map()
        {
            var list = new List<ITransaction>();

            if(Cancellation != null)
            {
                list.Add(Cancellation.Map());
            }

            return new CancellationsList(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}