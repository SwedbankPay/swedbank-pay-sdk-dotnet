using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class ReversalResponse : IdLink
    {
        public ReversalResponse(TransactionResponse transaction)
        {
            Transaction = transaction;
        }


        public TransactionResponse Transaction { get; }
    }
}