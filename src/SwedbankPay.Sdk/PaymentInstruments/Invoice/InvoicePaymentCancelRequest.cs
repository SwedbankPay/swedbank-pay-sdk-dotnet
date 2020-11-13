namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentCancelRequest
    {
        public InvoicePaymentCancelRequest(ICancelTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Details needed to cancel the current invoice payment.
        /// </summary>
        public ICancelTransaction Transaction { get; }

    }
}