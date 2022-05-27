using System;

namespace SwedbankPay.Sdk
{
    internal class CaptureResponseDto
    {
        public Uri Payment { get; set; }

        public TransactionResponseDto Capture { get; set; }
    }
}