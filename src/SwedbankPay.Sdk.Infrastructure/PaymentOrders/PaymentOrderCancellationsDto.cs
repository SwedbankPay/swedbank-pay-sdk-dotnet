using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancellationsDto
    {
        public string Id { get; set; }
        public TransactionDto Cancellation { get; set; }

        internal ICancellationsListResponse Map()
        {
            var list = new List<ITransaction>
            {
                Cancellation.Map()
            };

            return new CancellationsListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}