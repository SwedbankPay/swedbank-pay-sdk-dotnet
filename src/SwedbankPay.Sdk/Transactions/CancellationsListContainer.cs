namespace SwedbankPay.Sdk.Transactions
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class CancellationsListContainer : IdLink
    {
        public List<TransactionContainerResponse> CancellationList { get; }


        public CancellationsListContainer()
        {
            CancellationList = new List<TransactionContainerResponse>();
        }

        [JsonConstructor]
        public CancellationsListContainer(List<TransactionContainerResponse> cancellationList)
        {
            CancellationList = cancellationList;
        }
    }
}