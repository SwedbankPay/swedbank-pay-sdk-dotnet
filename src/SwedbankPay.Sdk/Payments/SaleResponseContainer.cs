using System;

namespace SwedbankPay.Sdk.Payments
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, SaleListContainer sales)
        {
            Payment = payment;
            Sales = sales;
        }

        public Uri Payment { get; }
        public SaleListContainer Sales { get; }
    }
}