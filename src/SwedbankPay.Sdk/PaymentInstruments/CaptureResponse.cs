using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CaptureResponse
    {
        public CaptureResponse(Uri payment, TransactionResponse capture)
        {
            Payment = payment;
            Capture = capture;
        }


        public TransactionResponse Capture { get; }

        public Uri Payment { get; }
    }
}