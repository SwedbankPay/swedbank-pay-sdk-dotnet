namespace SwedbankPay.Client.Models.Vipps.PaymentAPI.Response
{
    using System.Collections.Generic;
    using SwedbankPay.Client.Models.Common;

    public class PricesContainer    
    {
        public List<Price> PriceList { get; set; } = new List<Price>();
    }
}