using System;

namespace SwedbankPay.Sdk.Payments
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