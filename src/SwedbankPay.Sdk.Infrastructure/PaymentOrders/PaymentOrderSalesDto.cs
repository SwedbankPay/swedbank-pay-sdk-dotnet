using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderSalesDto
    {
        public string Id { get; set; }
        public List<PaymentOrderSaleListDto> SaleList { get; set; }

        internal ISaleListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}