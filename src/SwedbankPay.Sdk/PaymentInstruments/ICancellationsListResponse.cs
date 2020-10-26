using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICancellationsListResponse
    {
        List<ITransaction> CancellationList { get; }
    }
}