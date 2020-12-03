using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderPaymentsDto
    {
        public string Id { get; set; }
        public List<PaymentOrderPaymentListDto> PaymentList { get; set; }
    }
}