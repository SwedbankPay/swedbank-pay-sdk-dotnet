using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class ReversalResponseDto
    {
        public Uri Payment { get; set; }
        public TransactionResponseDto Reversal { get; set; }
    }

    public class TransactionResponseDto
    {
        public Uri Id { get; set; }
        public TransactionDto Transaction { get; set; }

        internal ITransactionResponse Map()
        {
            return new TransactionResponse(Id.OriginalString, Transaction);
        }
    }
}