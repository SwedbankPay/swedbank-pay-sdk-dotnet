using System.Collections.Generic;
using SwedbankPay.Client.Models.Common;

namespace SwedbankPay.Client.Models.Response.Payment
{
    public class SaleListContainer : IdLink
    {
        public List<SaleResponse> SaleList { get; set; }
    }
}