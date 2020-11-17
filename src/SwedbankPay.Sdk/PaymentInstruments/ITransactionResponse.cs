
namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransactionResponse
    {
        /// <summary>
        /// Details on the current transaction.
        /// </summary>
        ITransaction Transaction { get; }
    }
}