namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoiceDetailsDto
    {
        public InvoiceDetailsDto(IInvoiceDetails invoice)
        {
            InvoiceType = invoice.InvoiceType.ToString();
        }

        public string InvoiceType { get; set; }
    }
}