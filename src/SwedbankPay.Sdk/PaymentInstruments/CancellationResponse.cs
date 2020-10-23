using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationResponse : ICancellationResponse
    {
        public CancellationResponse(Uri payment, ITransactionResponse cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }


        public ITransactionResponse Cancellation { get; }

        public Uri Payment { get; }
    }
}