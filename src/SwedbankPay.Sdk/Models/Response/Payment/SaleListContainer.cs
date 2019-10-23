namespace SwedbankPay.Sdk.Models.Response.Payment
{
    using System.Collections.Generic;
    using SwedbankPay.Sdk.Models.Common;

    public class SaleListContainer : IdLink
    {
        public List<SaleResponse> SaleList { get; set; }
    }
}