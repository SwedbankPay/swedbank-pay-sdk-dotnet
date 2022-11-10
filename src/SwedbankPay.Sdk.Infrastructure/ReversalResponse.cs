using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class ReversalResponse : IReversalResponse
{
    public ReversalResponse(Uri payment, ITransactionResponse reversal)
    {
        Payment = payment;
        Reversal = reversal;
    }


    public Uri Payment { get; }
    public ITransactionResponse Reversal { get; }
}