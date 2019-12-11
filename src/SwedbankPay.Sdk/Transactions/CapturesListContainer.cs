using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class CapturesListContainer : IdLink
    {
        public CapturesListContainer()
        {
            CaptureList = new List<TransactionContainerResponse>();
        }


        [JsonConstructor]
        public CapturesListContainer(List<TransactionContainerResponse> captureList)
        {
            CaptureList = captureList;
        }


        public List<TransactionContainerResponse> CaptureList { get; }
    }
}