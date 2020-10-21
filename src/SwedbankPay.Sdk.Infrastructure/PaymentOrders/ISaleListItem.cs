using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ISaleListItem
    {
        public Uri Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentType Type { get; }
        public State State { get; }
        public string Number { get; }
        public Amount Amount { get; }
        public Amount VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
    }
}