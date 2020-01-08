namespace SwedbankPay.Sdk.Payments.Swish.Transactions
{
    public class TransactionRequestContainer<T>
    {
        public TransactionRequestContainer(T transaction)
        {
            Transaction = transaction;
        }

        public T Transaction { get; }
    }
}