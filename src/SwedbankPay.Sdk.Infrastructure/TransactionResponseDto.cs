using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk
{
    internal class TransactionResponseDto
    {
        public string Id { get; set; }
        public TransactionDto Transaction { get; set; }

        internal ITransactionResponse Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new TransactionResponse(uri, Transaction);
        }
    }
}