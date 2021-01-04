using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class ReversalsListResponse : Identifiable, IReversalsListResponse
    {
        public ReversalsListResponse(Uri id, List<ITransactionResponse> reversalList)
            : base(id)
        {
            ReversalList = reversalList;
        }

        public List<ITransactionResponse> ReversalList { get; }
    }
}