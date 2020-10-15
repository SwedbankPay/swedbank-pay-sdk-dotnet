using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class CancelTransaction : ICancelTransaction
    {
        protected internal CancelTransaction(Operation transactionActivity, string payeeReference, string description)
        {
            TransactionActivity = transactionActivity;
            PayeeReference = payeeReference;
            Description = description;
        }

        public Operation TransactionActivity { get; }
        public string Description { get; }
        public string PayeeReference { get; }
    }
}