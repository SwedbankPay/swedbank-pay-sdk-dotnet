using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancellationResponseDto
    {
        public TransactionResponseDto Cancellation { get; set; }

        public Uri Payment { get; set; }
    }
}