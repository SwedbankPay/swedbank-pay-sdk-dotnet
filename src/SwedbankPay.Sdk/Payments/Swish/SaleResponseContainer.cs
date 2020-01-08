using System;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, SaleResponse sale)
        {
            Payment = payment;
            Sale = sale;
        }

        public Uri Payment { get; }
        public SaleResponse Sale { get; }
    }
}
