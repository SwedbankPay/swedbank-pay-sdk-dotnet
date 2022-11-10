using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk;

internal class CancellationListResponse : Identifiable, ICancellationListResponse
{
    public CancellationListResponse(Uri id, IList<ITransaction> cancellationList) : base(id)
    {
        CancellationList = cancellationList;
    }


    public IList<ITransaction> CancellationList { get; }
}