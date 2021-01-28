namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class ItemDto
    {
        public ItemDto() { }

        public ItemDto(PaymentOrderPaymentOptionsItems item)
        {
            CreditCard = new CreditCardItemDto(item.CreditCard);
            Invoice = new InvoiceItemDto(item.Invoice);
            Swish = new SwishItemDto(item.Swish);
        }

        public CreditCardItemDto CreditCard { get; }
        public InvoiceItemDto Invoice { get; }
        public SwishItemDto Swish { get; }
    }
}