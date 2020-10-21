using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCaptures
    {
        public string Id { get; set; }
        public List<PaymentOrderCaptureListDto> CaptureList { get; set; }
    }
}