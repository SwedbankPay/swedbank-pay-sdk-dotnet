using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureResponse : ICaptureResponse
    {
        public CaptureResponse(Uri payment, ITransaction capture)
        {
            Payment = payment;
            Capture = capture;
        }


        public ITransaction Capture { get; }

        public Uri Payment { get; }
    }
}