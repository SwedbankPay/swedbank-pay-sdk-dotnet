using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    internal class CaptureListResponse : Identifiable, ICaptureListResponse
    {
        public CaptureListResponse(Uri id, IList<ITransaction> captureList) : base(id)
        {
            CaptureList = captureList;
        }


        public IList<ITransaction> CaptureList { get; }
    }
}