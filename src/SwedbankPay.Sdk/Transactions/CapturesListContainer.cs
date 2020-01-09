using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Transactions
{
    public class CapturesListContainer : IdLink
    {
        public CapturesListContainer(Uri id, List<TransactionContainerResponse> captureList)
        {
            Id = id;
            CaptureList = captureList;
        }


        public List<TransactionContainerResponse> CaptureList { get; }
    }
}