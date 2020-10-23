using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureResponse : ICaptureResponse
    {
        public CaptureResponse(Uri payment, ITransactionResponse capture)
        {
            Payment = payment;
            Capture = capture;
        }


        public ITransactionResponse Capture { get; }

        public Uri Payment { get; }
    }
}