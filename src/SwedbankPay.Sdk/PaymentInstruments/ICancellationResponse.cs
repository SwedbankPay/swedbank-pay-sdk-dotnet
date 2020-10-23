using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICancellationResponse
    {
        ITransactionResponse Cancellation { get; }
        Uri Payment { get; }
    }
}