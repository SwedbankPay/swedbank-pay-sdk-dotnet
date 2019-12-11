namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Item
    {
        public CreditCard CreditCard { get; set; }
        public Invoice Invoice { get; set; }
        public Swish Swish { get; set; }
    }
}