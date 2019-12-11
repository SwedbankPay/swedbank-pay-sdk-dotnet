using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class CancellationsListContainer : IdLink
    {
        public CancellationsListContainer()
        {
            CancellationList = new List<TransactionContainerResponse>();
        }


        [JsonConstructor]
        public CancellationsListContainer(List<TransactionContainerResponse> cancellationList)
        {
            CancellationList = cancellationList;
        }


        public List<TransactionContainerResponse> CancellationList { get; }
    }
}