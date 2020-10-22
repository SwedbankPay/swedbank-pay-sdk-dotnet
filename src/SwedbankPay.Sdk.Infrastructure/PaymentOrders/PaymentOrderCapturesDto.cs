using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCapturesDto
    {
        public string Id { get; set; }
        public List<PaymentOrderCaptureListDto> CaptureList { get; set; }

        internal ICapturesListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}