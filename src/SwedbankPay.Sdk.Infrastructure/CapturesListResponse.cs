using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class CapturesListResponse : Identifiable, ICapturesListResponse
    {
        public CapturesListResponse(Uri id, List<ITransaction> captureList) : base(id)
        {
            CaptureList = captureList;
        }


        public IList<ITransaction> CaptureList { get; }
    }
}