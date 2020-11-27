using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class ReversalsListResponse : Identifiable, IReversalsListResponse
    {
        public ReversalsListResponse(Uri id, List<ITransactionResponse> reversalList)
        {
            Id = id;
            ReversalList = reversalList;
        }

        public List<ITransactionResponse> ReversalList { get; }
    }
}