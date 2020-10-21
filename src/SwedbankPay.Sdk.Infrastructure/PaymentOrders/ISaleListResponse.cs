using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal interface ISaleListResponse
    {
        public Uri Id { get; }
        public List<ISaleListItem> SaleList { get;  }
    }
}