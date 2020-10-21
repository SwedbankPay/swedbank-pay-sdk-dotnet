using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderPaymentsDto
    {
        public string Id { get; set; }
        public List<PaymentOrderPaymentListDto> PaymentList { get; set; }

        internal IdLink Map()
        {
            throw new NotImplementedException();
        }
    }
}