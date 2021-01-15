using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCapturesDto
    {
        public string Id { get; set; }
        public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

        internal ICapturesListResponse Map()
        {
            var list = new List<ITransaction>();

            foreach (var c in CaptureList)
            {
                list.Add(c.Map());
            }

            Uri id = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new CapturesListResponse(id, list);
        }
    }
}