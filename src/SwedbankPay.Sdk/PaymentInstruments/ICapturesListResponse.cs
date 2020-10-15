using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICapturesListResponse
    {
        List<TransactionResponse> CaptureList { get; }
    }
}