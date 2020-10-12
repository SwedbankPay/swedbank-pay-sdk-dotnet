using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public interface IReversalsListResponse
    {
        List<TransactionResponse> ReversalList { get; }
    }
}