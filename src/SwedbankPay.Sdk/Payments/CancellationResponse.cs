using System;

namespace SwedbankPay.Sdk.Payments
{
    public class CancellationResponse
    {
        public CancellationResponse(Uri payment, TransactionResponse cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }


        public TransactionResponse Cancellation { get; }

        public Uri Payment { get; }
    }
}