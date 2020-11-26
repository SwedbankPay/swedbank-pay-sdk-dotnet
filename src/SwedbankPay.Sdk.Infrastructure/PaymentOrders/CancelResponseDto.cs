using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancelResponseDto
    {
        public Uri Payment { get; set; }

        public TransactionResponseDto Cancellation { get; set; }
    }
}