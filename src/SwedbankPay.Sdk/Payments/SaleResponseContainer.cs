namespace SwedbankPay.Sdk.Payments
{
    using Newtonsoft.Json;

    public class SaleResponseContainer
    {
        public string Payment { get; }
        public SaleListContainer Sales { get; }


        public SaleResponseContainer()
        {
        }


        [JsonConstructor]
        public SaleResponseContainer(string payment, SaleListContainer sales)
        {
            Payment = payment;
            Sales = sales;
        }
    }
}