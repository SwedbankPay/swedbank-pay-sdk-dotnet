using System;

namespace SwedbankPay.Sdk.PaymentInstruments
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