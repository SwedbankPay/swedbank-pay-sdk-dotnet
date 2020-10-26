using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseDto
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentResponseDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }
    }
}