namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentCancelRequest
    {
        public InvoicePaymentCancelRequest(ICancelTransaction transaction)
        {
            Transaction = transaction;
        }


        public ICancelTransaction Transaction { get; }

    }
}