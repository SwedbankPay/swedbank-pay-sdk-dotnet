namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentReversalRequest : IInvoicePaymentReversalRequest
    {
        public InvoicePaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(activity, amount, vatAmount, description, payeeReference);
        }


        public IReversalTransaction Transaction { get; }
    }
}