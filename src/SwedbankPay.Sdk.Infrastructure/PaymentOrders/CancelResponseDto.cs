using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancelResponseDto
    {
        public Uri Payment { get; set; }

        public TransactionResponseDto Cancellation { get; set; }

        public ITransactionResponse Map()
        {
            return Cancellation.Map();
        }
    }
}