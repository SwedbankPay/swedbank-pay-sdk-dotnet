using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentReversalRequest
    {
        public InvoicePaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(activity, amount, vatAmount, description, payeeReference);
        }


        public IReversalTransaction Transaction { get; }
    }
}