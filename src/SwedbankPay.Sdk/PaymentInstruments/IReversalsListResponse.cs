using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IReversalsListResponse
    {
        List<TransactionResponse> ReversalList { get; }
    }
}