using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCurrentPaymentDto
    {
        public Uri Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentOrderPaymentDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }

        internal ICurrentPaymentResponse Map()
        {
            var payment = Payment != null ? new CurrentPayment(Payment) : null;
            return new CurrentPaymentResponse(Id, MenuElementName, payment);
        }
    }
}