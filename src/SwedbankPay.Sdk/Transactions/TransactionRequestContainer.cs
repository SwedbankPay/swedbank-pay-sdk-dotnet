namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionRequestContainer
    {
        public TransactionRequestContainer(TransactionRequest transaction)
        {
            Transaction = transaction;
        }


        public TransactionRequest Transaction { get; }
    }
}