using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class PricesContainer : IdLink
    {
        public List<Price> PriceList { get; set; } = new List<Price>();
    }
}