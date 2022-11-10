using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class TransactionResponse : Identifiable, ITransactionResponse
{
    public TransactionResponse(Uri id, TransactionDto transaction)
        : base(id)
    {
        Transaction = transaction?.Map();
    }

    public ITransaction Transaction { get; }
}
