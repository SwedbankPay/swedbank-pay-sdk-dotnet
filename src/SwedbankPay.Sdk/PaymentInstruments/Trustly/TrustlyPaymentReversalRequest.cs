using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentReversalRequest
    {
        public TrustlyPaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
        {
            Transaction = new ReversalTransaction(activity, amount, vatAmount, payeeReference, receiptReference, description);
        }


        public ReversalTransaction Transaction { get; }

        public class ReversalTransaction
        {
            public ReversalTransaction(Operation activity, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
            {
                TransactionActivity = activity;
                Amount = amount;
                VatAmount = vatAmount;
                Description = description;
                PayeeReference = payeeReference;
                RecepitReference = receiptReference;
            }

            public Operation TransactionActivity { get; }
            public Amount Amount { get; }
            public string Description { get; }
            public string PayeeReference { get; }
            public string RecepitReference { get; }
            public Amount VatAmount { get; }
        }
    }
}
