using System;

namespace SwedbankPay.Sdk.PaymentOrders;

internal class CancelResponseDto
{
    public Uri Payment { get; set; }

    public TransactionResponseDto Cancellation { get; set; }
}