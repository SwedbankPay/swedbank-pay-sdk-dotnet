using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CancellationsListResponse : IdLink, ICancellationsListResponse
    {
        public CancellationsListResponse(Uri id, List<TransactionResponse> cancellationList)
        {
            Id = id;
            CancellationList = cancellationList;
        }


        public List<TransactionResponse> CancellationList { get; }
    }
}