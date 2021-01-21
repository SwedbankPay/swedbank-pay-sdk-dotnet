using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class CancellationsList : Identifiable, ICancellationsList
    {
        public CancellationsList(Uri id, IList<ITransaction> cancellationList) : base(id)
        {
            CancellationList = cancellationList;
        }


        public IList<ITransaction> CancellationList { get; }
    }
}