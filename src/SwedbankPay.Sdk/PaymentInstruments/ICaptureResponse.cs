using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICaptureResponse
    {
        ITransaction Capture { get; }
        Uri Payment { get; }
    }
}