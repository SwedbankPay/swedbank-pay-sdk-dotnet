using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CaptureTransactionResponseDto
    {
        public IdLink Id { get; set; }
        public string Payment { get; set; }
        public List<PaymentOrderTransactionDto> Capture { get; set; }

        internal ICapturesListResponse Map()
        {
            throw new NotImplementedException();
        }
    }

}