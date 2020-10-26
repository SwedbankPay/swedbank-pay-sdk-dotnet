using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ISaleListResponse
    {
        public Uri Id { get; }
        public List<ISaleListItem> SaleList { get; }
    }
}