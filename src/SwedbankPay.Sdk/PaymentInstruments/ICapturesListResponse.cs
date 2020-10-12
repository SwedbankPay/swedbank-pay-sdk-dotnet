using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public interface ICapturesListResponse
    {
        List<TransactionResponse> CaptureList { get; }
    }
}