namespace SwedbankPay.Sdk.Transactions
{
    using System;

    using Newtonsoft.Json;

    internal class CaptureTransactionResponseContainer
    {
        public Uri Payment { get; }
        public TransactionContainer Capture { get; }


        public CaptureTransactionResponseContainer()
        {
        }


        [JsonConstructor]
        public CaptureTransactionResponseContainer(Uri payment, TransactionContainer capture)
        {
            Payment = payment;
            Capture = capture;
        }
    }
}