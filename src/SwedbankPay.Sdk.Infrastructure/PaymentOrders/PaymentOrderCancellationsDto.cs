using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancellationsDto
    {
        public string Id { get; set; }
        public List<PaymentOrderCancellationListDto> CancelList { get; set; }

        internal ICancellationsListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}