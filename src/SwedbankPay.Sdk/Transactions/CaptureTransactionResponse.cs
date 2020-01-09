using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class CaptureTransactionResponse
    {
        public CaptureTransactionResponse(Uri payment, TransactionResponse capture)
        {
            Payment = payment;
            Capture = capture;
        }


        public TransactionResponse Capture { get; }
        public Uri Payment { get; }
    }
}