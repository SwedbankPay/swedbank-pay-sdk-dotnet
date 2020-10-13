namespace SwedbankPay.Sdk.Payments.InvoicePayments
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