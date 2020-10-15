namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentCancelRequest
    {
        public InvoicePaymentCancelRequest(ICancelTransaction transaction)
        {
            Transaction = Transaction;
        }


        public ICancelTransaction Transaction { get; }

    }
}