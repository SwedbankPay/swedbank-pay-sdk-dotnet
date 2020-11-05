using SwedbankPay.Sdk.PaymentOrders;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CancellationResponseDto
    {
        public TransactionResponseDto Cancellation { get; set; }

        public Uri Payment { get; set; }
    }
}