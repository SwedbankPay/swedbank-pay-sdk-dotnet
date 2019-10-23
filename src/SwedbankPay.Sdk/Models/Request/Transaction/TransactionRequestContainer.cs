namespace SwedbankPay.Sdk.Models.Request.Transaction
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