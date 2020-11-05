using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancelResponseDto
    {
        public TransactionResponseDto Cancellation { get; }

        public Uri Payment { get; }

        public ITransactionResponse Map()
        {
            return Cancellation.Map();
        }
    }
}