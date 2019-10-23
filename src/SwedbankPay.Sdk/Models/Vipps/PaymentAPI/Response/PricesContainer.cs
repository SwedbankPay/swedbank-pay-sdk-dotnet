namespace SwedbankPay.Sdk.Models.Vipps.PaymentAPI.Response
{
    using System.Collections.Generic;
    using SwedbankPay.Sdk.Models.Common;

    public class PricesContainer    
    {
        public List<Price> PriceList { get; set; } = new List<Price>();
    }
}