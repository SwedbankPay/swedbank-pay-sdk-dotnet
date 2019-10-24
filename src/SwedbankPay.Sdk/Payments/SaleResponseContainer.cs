namespace SwedbankPay.Sdk.Payments
{
    public class SaleResponseContainer
    {
        public string Payment { get; protected set; }
        public SaleListContainer Sales { get; protected set; }
    }
}