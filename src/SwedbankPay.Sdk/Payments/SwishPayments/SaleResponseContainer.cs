using System;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, SwishPaymentSaleListResponse sales)
        {
            Payment = payment;
            Sales = sales;
        }


        public Uri Payment { get; }
        public SwishPaymentSaleListResponse Sales { get; }
    }
}