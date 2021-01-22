using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCaptureListDto
    {
        public string Id { get; set; }
        public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

        internal ICaptureListResponse Map()
        {
            var list = new List<ITransaction>();

            foreach (var captures in CaptureList)
            {
                list.Add(captures.Map());
            }

            Uri id = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new CaptureListResponse(id, list);
        }
    }
}