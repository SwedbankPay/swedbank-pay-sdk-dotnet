using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class ReversalsListResponse : IdLink, IReversalsListResponse
    {
        public ReversalsListResponse(Uri id, List<TransactionResponse> reversalList)
        {
            Id = id;
            ReversalList = reversalList;
        }


        public List<TransactionResponse> ReversalList { get; }
    }
}