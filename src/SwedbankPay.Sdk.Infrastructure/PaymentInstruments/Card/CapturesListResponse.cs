using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CapturesListResponse : IdLink, ICapturesListResponse
    {
        public CapturesListResponse(Uri id, List<ITransaction> captureList)
        {
            Id = id;
            CaptureList = captureList;
        }


        public List<ITransaction> CaptureList { get; }
    }
}