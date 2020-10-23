using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IReversalResponse
    {
        Uri Payment { get; }
        ITransactionResponse Reversal { get; }
    }
}