using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class AuthorizationListContainer : IdLink
    {
        public AuthorizationListContainer()
        {
            AuthorizationList = new List<TransactionContainerResponse>();
        }


        [JsonConstructor]
        public AuthorizationListContainer(List<TransactionContainerResponse> authorizationList)
        {
            AuthorizationList = authorizationList;
        }


        public List<TransactionContainerResponse> AuthorizationList { get; }
    }
}