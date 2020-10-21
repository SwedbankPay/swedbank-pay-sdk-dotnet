using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderTransactionListDto
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public object Number { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
        public bool IsOperational { get; set; }
        public List<HttpOperationDto> Operations { get; set; }
    }
}