using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCurrentPaymentDto
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentOrderPaymentDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }

        internal ICurrentPaymentResponse Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);

            if (Payment == null)
            {
                return new CurrentPaymentResponse(uri, MenuElementName, null);
            }

            var payment = new CurrentPaymentResponseObject(Payment);
            return new CurrentPaymentResponse(uri, MenuElementName, payment);
        }
    }
}