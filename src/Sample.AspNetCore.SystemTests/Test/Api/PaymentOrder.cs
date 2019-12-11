namespace Sample.AspNetCore.SystemTests.Test.Api
{
    public class PaymentOrder
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public CurrentPayment CurrentPayment { get; set; }
        public string Id { get; set; }
        public OrderItems OrderItems { get; set; }
        public string State { get; set; }
    }
}