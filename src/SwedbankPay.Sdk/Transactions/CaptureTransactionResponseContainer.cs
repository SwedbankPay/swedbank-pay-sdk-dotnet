using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class CaptureTransactionResponseContainer
    {
        public CaptureTransactionResponseContainer(Uri payment, TransactionContainer capture)
        {
            Payment = payment;
            Capture = capture;
        }


        public TransactionContainer Capture { get; }
        public Uri Payment { get; }
    }
}