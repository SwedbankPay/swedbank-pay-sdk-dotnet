namespace SwedbankPay.Sdk.Models.Response.Payment
{
    public class SaleResponseContainer
    {
        public string Payment { get; set; }
        public SaleListContainer Sales { get; set; }
    }
}