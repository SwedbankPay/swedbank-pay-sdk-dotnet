namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionRequestContainer
    {
        public TransactionRequest Transaction { get; }

        public TransactionRequestContainer(TransactionRequest transaction)
        {
            Transaction = transaction;
        }
    }
}