namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface IVerifyTransaction: ITransaction
    {
        string FailedReason { get; }

        string FailedActivityName { get; }

        string FailedErrorCode { get; }

        string FailedErrorDescription { get; }

        string Activities { get; }
    }
}