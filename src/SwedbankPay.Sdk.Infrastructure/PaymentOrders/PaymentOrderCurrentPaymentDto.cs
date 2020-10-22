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
            var payment = new CurrentPaymentResponseObject(Payment);
            new CurrentPaymentResponse(new Uri(Id, UriKind.RelativeOrAbsolute), MenuElementName, payment);
            throw new NotImplementedException();
        }
    }
}