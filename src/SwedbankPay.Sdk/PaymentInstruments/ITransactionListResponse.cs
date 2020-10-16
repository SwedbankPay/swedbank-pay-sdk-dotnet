using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransactionListResponse
    {
        Uri Id { get; }
        List<ITransaction> TransactionList { get; }
    }
}