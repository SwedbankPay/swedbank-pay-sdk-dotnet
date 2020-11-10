using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCapturesDto
    {
        public string Id { get; set; }
        public List<TransactionDto> Capture { get; set; } = new List<TransactionDto>();

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransaction>();

            foreach (var c in Capture)
            {
                list.Add(c.Map());
            }

            return new CapturesListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
        }
    }
}