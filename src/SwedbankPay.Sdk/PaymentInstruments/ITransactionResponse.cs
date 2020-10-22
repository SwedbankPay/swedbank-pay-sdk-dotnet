
namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransactionResponse
    {
        ITransaction Transaction { get; }
    }
}