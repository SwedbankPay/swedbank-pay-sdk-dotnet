using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public interface ICancellationsListResponse
    {
        List<TransactionResponse> CancellationList { get; }
    }
}