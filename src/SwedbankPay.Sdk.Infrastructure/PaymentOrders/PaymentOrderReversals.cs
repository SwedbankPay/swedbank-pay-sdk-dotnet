using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversals
    {
        public string Id { get; set; }
        public List<PaymentOrderReversalListDto> ReversalList { get; set; }

        internal IReversalsListResponse Map()
        {
            throw new NotImplementedException();
        }
    }
}