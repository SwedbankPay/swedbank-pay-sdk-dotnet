namespace Sample.AspNetCore3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentOrderLink { get; set; }
        public string PaymentLink { get; set; }
    }
}