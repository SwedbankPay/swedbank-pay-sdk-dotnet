using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishSaleListResponse
    {
        public Uri Id { get; }
        public List<ISwishSaleListItem> SaleList { get; }
    }
}