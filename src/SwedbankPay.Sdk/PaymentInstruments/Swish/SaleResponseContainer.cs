using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer(Uri payment, ISwishSaleListResponse sales)
        {
            Payment = payment;
            Sales = sales;
        }


        public Uri Payment { get; }
        public ISwishSaleListResponse Sales { get; }
    }
}