namespace SwedbankPay.Client.Models.Common
{
    public class Item
    {
        public CreditCard CreditCard { get; set; }
        public Invoice Invoice { get; set; }
        public Swish Swish { get; set; }
    }
}
