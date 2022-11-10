using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk;

internal class ReversalListResponse : Identifiable, IReversalListResponse
{
    public ReversalListResponse(Uri id, List<ITransactionResponse> reversalList)
        : base(id)
    {
        ReversalList = reversalList;
    }

    public IList<ITransactionResponse> ReversalList { get; }
}