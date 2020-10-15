using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class CapturesListResponse : IdLink, ICapturesListResponse
    {
        public CapturesListResponse(Uri id, List<TransactionResponse> captureList)
        {
            Id = id;
            CaptureList = captureList;
        }


        public List<TransactionResponse> CaptureList { get; }
    }
}