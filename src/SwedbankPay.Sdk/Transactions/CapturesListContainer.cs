namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class CapturesListContainer : IdLink
    {
        public List<TransactionContainerResponse> CaptureList { get; }

        public CapturesListContainer() 
        {
            CaptureList = new List<TransactionContainerResponse>();
        }


        [JsonConstructor]
        public CapturesListContainer(List<TransactionContainerResponse> captureList)
        {
            CaptureList = captureList;
        }
    }
}