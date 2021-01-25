using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk
{
    internal class CaptureResponseDto
    {
        public string Payment { get; set; }

        public TransactionDto Capture { get; set; }

        public ITransaction Map()
        {
            return Capture.Map();
        }
    }
}