using SwedbankPay.Sdk.Payments.InvoicePayments;

namespace SwedbankPay.Sdk.Payments
{
    internal class InvoicePayment : IInvoicePayment
    {
        private InvoicePaymentDto payment;

        public InvoicePayment(InvoicePaymentDto payment)
        {
            this.payment = payment;
        }
    }
}