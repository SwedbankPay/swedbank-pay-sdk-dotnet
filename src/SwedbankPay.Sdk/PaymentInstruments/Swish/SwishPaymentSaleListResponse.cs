using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISaleListResponse
    {
        public Uri Id { get; }
        public List<ISaleListItem> SaleList { get; }
    }
}