namespace SwedbankPay.Sdk.PaymentOrders;

internal class InvoiceItemDto
{
    public InvoiceItemDto(Invoice invoice)
    {
        if(invoice == null)
        {
            return;
        }

        FeeAmount = invoice.FeeAmount;
    }

    public int? FeeAmount { get; set; }
}