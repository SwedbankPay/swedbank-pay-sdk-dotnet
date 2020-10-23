using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICaptureResponse
    {
        ITransactionResponse Capture { get; }
        Uri Payment { get; }
    }
}