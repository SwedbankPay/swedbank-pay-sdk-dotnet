namespace SwedbankPay.Sdk.Payments
{
    using System.Collections.Generic;

    public class PricesContainer : IdLink
    {
        public List<Price> PriceList { get; set; } = new List<Price>();
    }
}