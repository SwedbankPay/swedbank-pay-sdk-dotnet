using System;

namespace SwedbankPay.Sdk;

internal class ReversalResponseDto
{
    public Uri Payment { get; set; }
    public TransactionResponseDto Reversal { get; set; }
}