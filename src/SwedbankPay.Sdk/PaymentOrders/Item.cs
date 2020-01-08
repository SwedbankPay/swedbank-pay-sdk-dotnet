namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Item
    {
        public Item(CreditCard creditCard, Invoice invoice, Swish swish)
        {
            CreditCard = creditCard;
            Invoice = invoice;
            Swish = swish;
        }

        public CreditCard CreditCard { get; }
        public Invoice Invoice { get; }
        public Swish Swish { get; }
    }
}