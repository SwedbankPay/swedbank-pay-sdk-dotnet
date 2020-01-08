namespace SwedbankPay.Sdk.Payments
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