using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CancellationsListResponse : IdLink, ICancellationsListResponse
    {
        public CancellationsListResponse(Uri id, List<ITransaction> cancellationList)
        {
            Id = id;
            CancellationList = cancellationList;
        }


        public List<ITransaction> CancellationList { get; }
    }
}