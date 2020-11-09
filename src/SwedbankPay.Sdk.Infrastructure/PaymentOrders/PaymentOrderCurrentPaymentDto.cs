using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCurrentPaymentDto
    {
        public Uri Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentOrderPaymentDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }

        internal ICurrentPaymentResponse Map()
        {
            if (Payment == null)
            {
                return new CurrentPaymentResponse(Id, MenuElementName, null);
            }

            var payment = new CurrentPayment(Payment);
            return new CurrentPaymentResponse(Id, MenuElementName, payment);
        }
    }
}