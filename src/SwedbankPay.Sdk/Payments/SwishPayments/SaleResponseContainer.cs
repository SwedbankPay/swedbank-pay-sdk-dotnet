using System;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, SaleListResponse sales)
        {
            Payment = payment;
            Sales = sales;
        }


        public Uri Payment { get; }
        public SaleListResponse Sales { get; }
    }
}