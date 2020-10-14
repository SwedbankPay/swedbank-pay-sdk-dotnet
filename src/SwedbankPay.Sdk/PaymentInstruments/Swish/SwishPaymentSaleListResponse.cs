using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public interface ISaleListResponse
    {
        public Uri Id { get; }
        public List<ISaleListItem> SaleList { get; }
    }
}