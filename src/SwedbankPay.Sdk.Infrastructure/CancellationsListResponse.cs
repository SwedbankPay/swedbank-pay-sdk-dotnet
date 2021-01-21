using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class CancellationsListResponse : Identifiable, ICancellationsListResponse
    {
        public CancellationsListResponse(Uri id, IList<ITransaction> cancellationList) : base(id)
        {
            CancellationList = cancellationList;
        }


        public IList<ITransaction> CancellationList { get; }
    }
}