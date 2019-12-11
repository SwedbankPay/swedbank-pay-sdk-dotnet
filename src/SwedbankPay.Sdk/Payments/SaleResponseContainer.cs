using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Payments
{
    public class SaleResponseContainer
    {
        public SaleResponseContainer()
        {
        }


        [JsonConstructor]
        public SaleResponseContainer(string payment, SaleListContainer sales)
        {
            Payment = payment;
            Sales = sales;
        }


        public string Payment { get; }
        public SaleListContainer Sales { get; }
    }
}