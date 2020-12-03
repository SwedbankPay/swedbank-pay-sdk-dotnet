
namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Interface describes a object having a Transaction.
    /// </summary>
    public interface ITransactionResponse
    {
        /// <summary>
        /// Details on the current transaction.
        /// </summary>
        ITransaction Transaction { get; }
    }
}