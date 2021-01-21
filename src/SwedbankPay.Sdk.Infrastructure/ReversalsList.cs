using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class ReversalsList : Identifiable, IReversalsList
    {
        public ReversalsList(Uri id, List<ITransactionResponse> reversalList)
            : base(id)
        {
            ReversalList = reversalList;
        }

        public IList<ITransactionResponse> ReversalList { get; }
    }
}