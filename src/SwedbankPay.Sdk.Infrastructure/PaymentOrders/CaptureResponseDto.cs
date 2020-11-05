using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CaptureResponseDto
    {
        public Uri payment { get; set; }

        public TransactionDto Capture { get; set; }

        public ITransaction Map()
        {
            return Capture.Map();
        }
    }
}