using System;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, ISaleListResponse sales)
        {
            Payment = payment;
            Sales = sales;
        }


        public Uri Payment { get; }
        public ISaleListResponse Sales { get; }
    }
}